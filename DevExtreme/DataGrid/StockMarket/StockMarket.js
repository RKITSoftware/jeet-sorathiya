window.jsPDF = window.jspdf.jsPDF;

$(() => {
    let exportToPdf = false;
    const url = 'http://localhost:57766'; 
    const stockStore = new DevExpress.data.CustomStore({
        key: 'Id',
        load: function (loadOptions) {
            const params = {
                skip: loadOptions.skip || 0,
                take: loadOptions.take || 10,
                sort: JSON.stringify(loadOptions.sort) || null,
                filter: JSON.stringify(loadOptions.filter) || null,
            };

            return $.ajax({
                url: `${url}/Stocks`,
                method: 'GET',
                data: params,
                dataType: 'json',
                success: function (result) {
                    return {
                        data: result.data,
                        totalCount: result.totalCount
                    };
                },
                error: function (error) {
                    throw new Error('Data Loading Error');
                }
            });
        },
        //load: (loadOptions) => {
        //    const params = {
        //        skip: loadOptions.skip || 0,
        //        take: loadOptions.take || 3
        //    };
        //    return $.ajax({
        //        url: `${url}/Stocks`,
        //        method: 'GET',
        //        data: params, // Send parameters as data
        //        dataType: 'json', // Ensure expected data type
        //        success: (result) => {
        //            return {
        //                data: result.data,
        //                totalCount: result.totalCount
        //            };
        //        },
        //        error: () => {
        //            throw new Error('Data Loading Error');
        //        }
        //    });
        //},
        byKey: function (key) {
            return $.ajax({
                type: "GET",
                url: `${url}/Stocks/${key}`,
                success: (data) => {
                    console.log("Data Fetched Successfully");
                    return data;
                },
                error: (e) => {
                    console.log("Data Not Fetched");
                }
            });
        },
        insert: (values) => {
            console.log(values)
            return $.ajax({
                url: `${url}/Stocks`,
                method: 'POST',
                data: JSON.stringify(values),
                contentType: 'application/json'
            });
        },
        update: (key, values) => {
            return $.ajax({
                url: `${url}/Stocks/${key}`,
                method: 'PUT',
                data: JSON.stringify(values),
                contentType: 'application/json'
            });
        },
        remove: (key) => {
            return $.ajax({
                url: `${url}/Stocks/${key}`,
                method: 'DELETE'
            });
        }
    });

    const stockTypeStore = new DevExpress.data.CustomStore({
        load: async function () {
            return await $.ajax({
                type: "GET",
                url: `${url}/types`,
                success: (e) => {
                    console.log("Data Fetched Successfully");
                },
                error: (e) => {
                    console.log("Data Not Fetched");
                }
            })
        },  
        byKey: async function (key) {
            try {
                const response = await $.ajax({
                    type: "GET",
                    url: `${url}/types/${key}`,
                    success: (data) => {
                        console.log("Stock Type Fetched Successfully");
                        return data;
                    },
                    error: (error) => {
                        console.log("Error fetching stock type by key:", error);
                        throw error;
                    }
                });
                return response;
            } catch (error) {
                console.error("Error in byKey method for stock type:", error);
                throw error;
            }
        }
       
    });

    const dataGrid =  $('#gridContainer').dxDataGrid({
       // height: 400,
        dataSource: stockStore,
        remoteOperations: {
            paging: true,
        },
        //remoteOperations: true,
        showBorders: true,
        paging: {
            enabled: true,
            pageSize: 3, // total record in one page
            pageIndex: 0   // page index that show
        },
        pager: {
            visible: true,
            showPageSizeSelector: true, // set how many record show in one page
            allowedPageSizes: [3, 5, 10, 50], // set how many record show in one page
            showNavigationButtons: true, // show arrow for navigation
            showInfo: true, // enable info text
            infoText: "Page #{0}. Total: {1} ({2} items)", // info text
        },
        //scrolling: {
        //    mode: 'standard'
        //},
        filterRow: {
            visible: true
        },
        filterPanel: { visible: true },
        filterSyncEnabled: true,
        filterBuilderPopup: {
            position: {
                of: window, at: 'top', my: 'top', offset: { y: 10 },
            },
        },
        stateStoring: {
            enabled: true,
            storageKey: "StockMarketGUI",
            type: "localStorage",
        },
        searchPanel: {
            visible: true,
            highlightCaseSensitive: true
        },
        groupPanel: {
            visible: true
        },
        grouping: {
            contextMenuEnabled: true,
            expandMode: 'rowClick',
        },
        onOptionChanged: function (e) {
            console.log("onOptionChanged",e);

            //if (e.fullName.includes("groupIndex") || e.fullName.includes("grouping")) {
            //    collapseButtonInstance.option("visible", true)
            //}
            //else {
            //    collapseButtonInstance.option("visible", false)
            //}
            ///////////
            //let x = e.component;
            //const columns = x.getVisibleColumns();
            //console.log("columns", columns)
            ////const groupedColumns = columns.filter(column => column.groupIndex !== undefined || column.groupIndex >= 0);
            //const groupedColumns = columns.filter(column => column.groupIndex !== undefined);
            //console.log("groupedColumns",groupedColumns)
            //if (groupedColumns.length > 0) {
            //    console.log("Grouped Columns:");
            //    groupedColumns.forEach(column => {
            //        console.log(`Column: ${column.dataField}, Group Index: ${column.groupIndex}`);
            //    });
            //} else {
            //    console.log("No columns are currently grouped.");
            //}
        },
        sorting: {
            mode: 'multiple'
        },
        selection: {
            mode: 'multiple'
        },
        rowAlternationEnabled: true,
        columnAutoWidth: true,
        columnChooser: {
            enabled: true
        },
        editing: {
            mode: 'popup',
            allowAdding: true,
            allowUpdating: true,
            allowDeleting: true,
            popup: {
                title: "Stock Info",
                showTitle: true,
                width: 700,
                height: 525
            },
            form: {
                items: [
                    { dataField: 'CompanyName', caption: 'Company Name' },
                    { dataField: 'NseSymbol', caption: 'NSE Symbol' },
                    {
                        dataField: 'StockTypeId',
                        caption: 'Stock Type',
                        editorType: 'dxSelectBox',
                        editorOptions: {
                            dataSource: stockTypeStore,
                            displayExpr: 'Type',
                            valueExpr: 'Id'
                        }
                    },
                    { dataField: 'MarketPrice', caption: 'Market Price', dataType: 'number' },
                    { dataField: 'TodayLow', caption: 'Today Low', dataType: 'number' },
                    { dataField: 'TodayHigh', caption: 'Today High', dataType: 'number' },
                    { dataField: 'Week52Low', caption: '52 Week Low', dataType: 'number' },
                    { dataField: 'Week52High', caption: '52 Week High', dataType: 'number' },
                    { dataField: 'MarketCap', caption: 'Market Cap', dataType: 'number' }
                ]
            }
        },
        //onInitNewRow: function (e) {
        //    console.log("onInitNewRow", e);
        //},
        //onEditingStart: function (e) {
        //    console.log("onEditingStart", e);
        //},
        //onRowInserting: function (e) {
        //    console.log("onRowInserting", e);
        //},
        //onRowUpdating: function (e) {
        //    console.log("onRowUpdating",e);
        //},
        columns: [
            { dataField: 'Id'},
            {
                dataField: 'CompanyName',
                caption: 'Company Name',
                validationRules: [{ type: 'required', message: 'Company Name is required' }]
            },
            {
                dataField: 'NseSymbol',
                caption: 'NSE Symbol',
                validationRules: [{ type: 'required', message: 'NSE Symbol is required' }],
            },
            {
                dataField: 'StockTypeId',
                caption: 'Stock Type',
                validationRules: [{ type: 'required', message: 'Stock Type is required' }],
                lookup: {
                    dataSource: stockTypeStore,
                    displayExpr: 'Type',
                    valueExpr: 'Id'
                },
            },
            {
                dataField: 'MarketPrice',
                caption: 'Market Price',
                dataType: 'number',
                validationRules: [
                    { type: 'required', message: 'Market Price is required' },
                    { type: 'range', min: 0.01, message: 'Market Price must be greater than zero' }
                ]
            },
            {
                dataField: 'TodayLow',
                caption: 'Today Low',
                dataType: 'number',
                visible: false,
                validationRules: [
                    { type: 'required', message: 'Today Low is required' },
                    { type: 'range', min: 0, message: 'Today Low must be at least zero' }
                ]
            },
            {
                dataField: 'TodayHigh',
                caption: 'Today High',
                dataType: 'number',
                visible: false,
                validationRules: [
                    { type: 'required', message: 'Today High is required' },
                    { type: 'range', min: 0, message: 'Today High must be at least zero' }
                ]
            },
            {
                dataField: 'Week52Low',
                caption: '52 Week Low',
                dataType: 'number',
                visible: false,
                validationRules: [
                    { type: 'required', message: '52 Week Low is required' },
                    { type: 'range', min: 0, message: '52 Week Low must be at least zero' }
                ]
            },
            {
                dataField: 'Week52High',
                caption: '52 Week High',
                dataType: 'number',
                visible: false,
                validationRules: [
                    { type: 'required', message: '52 Week High is required' },
                    { type: 'range', min: 0, message: '52 Week High must be at least zero' }
                ]
            },
            {
                dataField: 'MarketCap',
                caption: 'Market Cap',
                dataType: 'number',
                visible: false,
                validationRules: [
                    { type: 'required', message: 'Market Cap is required' },
                    { type: 'range', min: 0, message: 'Market Cap must be at least zero' }
                ]
            }
        ],
        masterDetail: {
            enabled: true,
            template: function (container, options) {
                const currentStockData = options.data;
                $('<div>').dxDataGrid({
                    dataSource: [currentStockData],
                    showBorders: true,
                    columns: [
                        { dataField: 'TodayLow', caption: 'Today Low', dataType: 'number' },
                        { dataField: 'TodayHigh', caption: 'Today High', dataType: 'number' },
                        { dataField: 'Week52Low', caption: '52 Week Low', dataType: 'number' },
                        { dataField: 'Week52High', caption: '52 Week High', dataType: 'number' },
                        { dataField: 'MarketCap', caption: 'Market Cap', dataType: 'number' }
                    ]
                }).appendTo(container);
            }
        },
        //onSelectionChanged(e) {
        //    e.component.refresh(true);
        //},
        onToolbarPreparing: function (e) {
            let toolbarItems = e.toolbarOptions.items;
            toolbarItems.push({
                location: 'before',
                widget: 'dxButton',
                options: {
                    visible: false,
                    text: 'Collapse All',
                    width: 136,
                    onClick(e) {
                        const expanding = e.component.option('text') === 'Expand All';
                        dataGrid.option('grouping.autoExpandAll', expanding);
                        e.component.option('text', expanding ? 'Collapse All' : 'Expand All');
                    },
                    onInitialized: function (e) {
                        collapseButtonInstance = e.component;
                    }
                },
            }),
                toolbarItems.push({
                    location: 'after',
                    widget: 'dxCheckBox',
                    options: {
                        text: 'pdf',
                        onValueChanged: function (e) {
                            exportToPdf = e.value;
                        }
                    }
                })
        },
        export: {
            enabled: true,
            allowExportSelectedData: true,
            //customizeExcelCell: function (e) {
            //    e.backgroundColor = "#F64F2B" 
            //    console.log(e);
            //}
        },
        onExporting: function (e) {
            if (exportToPdf) {
                exportPdf(e);
            }
            else {
                exportExcel(e);
            }
            e.cancel = true;
        },
        
        summary: {
            totalItems: [{
                column: 'MarketPrice',
                summaryType: 'sum',
                displayFormat: 'Total: {0}'
            }],
            groupItems: [{
                column: 'MarketPrice',
                summaryType: 'sum',
                displayFormat: 'Total: {0}'
            }]
        }
    }).dxDataGrid('instance');
});

function exportExcel(e) {
    var workbook = new ExcelJS.Workbook();
    var worksheet = workbook.addWorksheet('Main sheet');
    DevExpress.excelExporter.exportDataGrid({
        worksheet: worksheet,
        component: e.component,
        topLeftCell: { row: 1, column: 1 },
        customizeCell: function (options) {
            var excelCell = options;
            excelCell.font = { name: 'Arial', size: 12 };
            excelCell.alignment = { horizontal: 'left' };
        }
    }).then(function () {
        workbook.xlsx.writeBuffer().then(function (buffer) {
            saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'DataGrid.xlsx');
        });
    });
}

function exportPdf(e) {
    const doc = new jsPDF();

    DevExpress.pdfExporter.exportDataGrid({
        jsPDFDocument: doc,
        component: e.component,
        indent: 5,
    }).then(() => {
        doc.save('Companies.pdf');
    });
}