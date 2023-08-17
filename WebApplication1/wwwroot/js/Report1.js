


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
						dataField: 'goodId',
						caption: 'Товар',
						lookup: {
							dataSource: Connector.GMODEL.goods,
							displayExpr: 'name',
							valueExpr: 'id',
						}
					}
					,
					{
						dataField: 'id',
						caption: 'Партия',
						allowEditing: false,
						sortOrder: "asc",
						width: 160,

					}, {
						dataField: 'q',
						caption: 'Количество',
						width: 160,
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
						dataGrid2.filter(['storeId', '=', data.id]); 
					}
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
						dataField: 'pharmID',
						caption: 'Аптека',
						sortOrder: "asc",
						lookup: {
							dataSource: Connector.GMODEL.pharms,
							displayExpr: 'name',
							valueExpr: 'id',
						}
					}, {
						dataField: 'name',
						caption: 'Склад',
						sortOrder: "asc",
					}
				]
			}).dxDataGrid('instance');
			dataGrid1.option('dataSource', Connector.GMODEL.stores);
			dataGrid2.option('dataSource', Connector.GMODEL.lots);
			dataGrid2.filter(['storeId', '=', null]);
		});
	}

	catch (e) { console.log(e); }
});