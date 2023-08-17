


window.addEventListener("load", async () => {
	try {
		Connector.GMODEL.fillAll().then((x) => {
			const dataGrid2 = $('#grid2').dxDataGrid({
				height: '95%',
				width: '95%',
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
					allowAdding: false,
					allowUpdating: false,
					allowDeleting: false,
				},
				columns: [
					{
						dataField: 'name',
						caption: 'Товар',

					}, {
						dataField: 'n',
						caption: 'Количество',
					}
				]
			}).dxDataGrid('instance');

			const dataGrid1 = $('#grid1').dxDataGrid({
				height: '95%',
				width: '95%',
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
				onSelectionChanged(selectedItems) {
					const data = selectedItems.selectedRowsData[0];
					if (data) {
						dataGrid2.filter(['id', '=', data.id]);
					}
				},
				showBorders: true,
				dataSource: [],
				editing: {
					mode: 'row',
					allowAdding: false,
					allowUpdating: false,
					allowDeleting: false,
				},
				columns: [
					{
						dataField: 'name',
						caption: 'Аптека',
						sortOrder: "asc",
					}
				]
			}).dxDataGrid('instance');

			dataGrid1.option('dataSource', Connector.GMODEL.pharms);
			dataGrid2.option('dataSource', Connector.GMODEL.GoodsByPharm);
			dataGrid2.filter(['id', '=', null]);
		}
		)
	}

	catch (e) { console.log(e); }
});