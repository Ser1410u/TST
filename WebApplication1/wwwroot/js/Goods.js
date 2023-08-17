const WHAT = "goods";
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
			repaintChangesOnly: true,
			onSaving(e) {
				const change = e.changes[0];
				if (change) {
					e.cancel = true;
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
				dataField: 'name',
				caption: 'Наименование',
			}]
		}).dxDataGrid('instance');
		Connector.GMODEL.fillAll().then((x) => { dataGrid.option('dataSource', Connector.GMODEL[WHAT]); });
	}
	//$('#grid').dxDataGrid({


	/*		const listWidget = $('#listContainer').dxList({
						dataSource: Connector.GMODEL.stores,
						height: 400,
						width: 300,
						searchEnabled: true,
						searchExpr: 'name',
						itemTemplate(data) {
							return $('<div>').text(data.name);
						},
					}).dxList('instance');*/

	catch (e) { console.log(e); }
});