const WHAT = "lots";
function saveChange(change) {
	switch (change.type) {
		case 'insert':
			change.data.id = null;
			return Connector.GMODEL.IU(WHAT, change.data).then((x) => { if (!x.success) throw (x.description); return x.payload[0]; });
		case 'update':
			change.data.id = change.key;
			return Connector.GMODEL.IU(WHAT, change.data).then((x) => { if (!x.success) throw (x.description); return x.payload[0]; });
		case 'remove':
			return Connector.GMODEL.D(WHAT, change.key).then((x) => { if (!x.success) throw (x.description);; return x });
		default:
			return null;
	}
}


window.addEventListener("load", async () => {
	try {
		Connector.GMODEL.fillAll().then((x) => {
			const dataGrid = $('#grid').dxDataGrid({
				height: '800px',
				scrolling: {
					mode: 'virtual',
					rowRenderingMode: 'virtual',
				},
				paging: {
					pageSize: 100,
				},
				headerFilter: {
					visible: true,
					search: {
						enabled: true,
					},
				},
				selection: {
					mode: "single" // or "multiple" | "none"
				},
				keyExpr: 'id',
				showBorders: true,
				dataSource: [],
				editing: {
					mode: 'row',
					allowAdding: true,
					allowUpdating: true,
					allowDeleting: true,
					confirmDelete: false,
					useIcons: true,
				},
				onEditorPreparing(e) {
					if (e.parentType === 'dataRow' && e.dataField === 'storeId') {
						e.editorOptions.disabled = (typeof e.row.data.pharmID !== 'number');
					}
				},
				repaintChangesOnly: true,
				onSaving(e) {
					const change = e.changes[0];
					if (change) {
						e.cancel = true;
						if (change.type !== 'insert') {
							change.data = Connector.operateRecordForUpdate(dataGrid.option('dataSource'), change.data, change.key)
						}
						e.promise = saveChange(change)
							.then((data) => {
								let _data = e.component.option('dataSource');

								if (change.type === 'insert') {
									change.data = data;
								}
								_data = DevExpress.data.applyChanges(_data, [change], { keyExpr: 'id' });

								e.component.option({
									dataSource: _data,
									editing: {
										editRowKey: null,
										changes: [],
									},
								});
							});
					}
				},
				columns: [{
					dataField: 'id',
					allowEditing: false,
					sortOrder: "asc",
					width: 60,
				}, {
					dataField: 'pharmID',
					caption: 'Аптека',
					setCellValue(rowData, value) {
						rowData.pharmID = value;
						rowData.storeId = null;
					},
					lookup: {
						dataSource: Connector.GMODEL.pharms,
						displayExpr: 'name',
						valueExpr: 'id',
					}
				}, {
					dataField: 'storeId',
					caption: 'Склад',
					lookup: {
						dataSource(options) {
							return {
								store: Connector.GMODEL.stores,
								filter: options.data ? ['pharmID', '=', options.data.pharmID] : null,
							};
						},
						displayExpr: 'name',
						valueExpr: 'id',
					}
					}, {
						dataField: 'goodId',
						caption: 'Товар',
						lookup: {
							dataSource: Connector.GMODEL.goods,
							displayExpr: 'name',
							valueExpr: 'id',
						}
					}, {
					dataField: 'q',
					caption: 'кол-во',
				}
				]
			}).dxDataGrid('instance');
			dataGrid.option('dataSource', Connector.GMODEL[WHAT]);

		});
	}

	catch (e) { console.log(e); }
});