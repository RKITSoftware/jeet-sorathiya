window.jsPDF = window.jspdf.jsPDF;

$(function () {
    let exportToPdf = false;

    let apiData = new DevExpress.data.CustomStore({
        key: "id",
        load: async function () {
            return await $.ajax({
                type: "GET",
                url: "https://665d8d6de88051d604072435.mockapi.io/api/users/user",
                success: (e) => {
                    console.log("Data Fetched Successfully");
                },
                error: (e) => {
                    console.log("Data Not Fetched");
                }
            })
        }
    });

    const dataGrid = $("#dtFilter").dxDataGrid({
        dataSource: apiData,
        paging: {
            pageSize: 10, // total record in one page
            pageIndex: 0   // page index that show
        },
        pager: {
            showPageSizeSelector: true, // set how many record show in one page
            // displayMode: "compact", // style of page-size-selector
            allowedPageSizes: [10, 20, 50], // set how many record show in one page
            showNavigationButtons: true, // show arrow for navigation
            showInfo: true, // enable info text
            infoText: "Page #{0}. Total: {1} ({2} items)", // info text
        },
        filterRow: {
            visible: true,
            //   applyFilter: 'onClick',
        }, // add filter to each column
        headerFilter: { visible: true },
        searchPanel: { visible: true }, // add serach panel
        // filterValue: [['name', '=', 'Jeet']],
        filterPanel: { visible: true },
        filterSyncEnabled: true,
        //filterBuilder: {
        //    customOperations: [{
        //        name: 'jeet',
        //        caption: 'jeets',
        //       dataTypes: ['number'],
        //        icon: 'check',
        //        hasValue: false,
        //        calculateFilterExpression(value, field) {
        //            console.log(value, field);
        //            return [field.dataField, '=', 1];
        //        },
        //    }],
        //    allowHierarchicalFields: true,
        //},
        filterBuilderPopup: {
            position: {
                of: window, at: 'top', my: 'top', offset: { y: 10 },
            },
        },
        sorting: {
            mode: "multiple", // or "single" || "none"
        },
        selection: {
            allowSelectAll: true,
            mode: 'multiple',
            selectAllMode: "page", //'allPages' | 'page',
            showCheckBoxesMode: 'onLongTap', // 'always' | 'none' | 'onClick' | 'onLongTap'
        },
        editing: {
            mode: 'batch',
            allowAdding: true,
            allowUpdating: true,
            allowDeleting: true,
        },
        allowColumnReordering: true, // reorder column
        allowColumnResizing: true, // resize column
        columnChooser: { enabled: true }, // remove column from list
        columnAutoWidth: true,

        columnFixing: {
            enabled: true,
            columnHidingEnabled: true,
        }, // column  position fixing
        // columnResizingMode: "widget
        stateStoring: {
            enabled: true,
            storageKey: "miracleGUI",
            type: "localStorage",
        },
        // Appearance :
        showColumnLines: true,
        showRowLines: true,
        showBorders: true,
        //loadPanel: {
        //    enabled: true,
        //},
        groupPanel: {
            visible: true,
        },
        grouping: {
            contextMenuEnabled: true,
            expandMode: 'rowClick',
        },
        rowAlternationEnabled: true,
        onOptionChanged: function (e) {
            console.log(e);

            if (e.fullName.includes("groupIndex") || e.fullName.includes("grouping")) {
                collapseButtonInstance.option("visible", true)
            }
            else {
                collapseButtonInstance.option("visible", false)
            }
        },
        columns: [
            {
                dataField: 'id',
                caption: "User Id",
                allowEditing: false,
                dataTypes: 'number',
                width: "110px",
                // allowSorting: false
                sortIndex: 0,
                sortOrder: "asc",
                //headerFilter: {
                //    groupInterval: 10,
                //},
                allowReordering: false
            },
            {
                dataField: 'name',
                width: "200px",
                validationRules: [{
                    type: "required",
                    message: "Enter Name"
                }, {
                    type: "stringLength",
                    min: 3,
                    max: 20,
                    message: "Enter Valid Name"
                }]
            },
            {
                dataField: 'email',
                width: "300px",
                validationRules: [{
                    type: "email"
                }]

            },
            {
                dataField: 'job',
                width: "300px",
                validationRules: [{
                    type: "required",
                    message: "Enter Job"
                }, {
                    type: "stringLength",
                    min: 3,
                    max: 50,
                    message: "Enter Valid Job Title"
                }]
            },
            {
                dataField: 'salary',
                //width:"300px",
                format: 'currency',
                validationRules: [{
                    type: "required",
                    message: "Enter Salary"
                }],
            },
            {
                caption: "Other Info",
                columns: [
                    {
                        dataField: 'dob',
                        width: "200px",
                        dataType: 'date',
                        validationRules: [{
                            type: "required",
                            message: "Enter DOB"
                        }]

                    },
                    {
                        dataField: 'gender',
                        caption: "gender",
                        width: "100px",
                        validationRules: [{
                            type: "required",
                            message: "Enter Gender"
                        }],
                        cellTemplate(container, options) {
                            if (options.value === "male") {
                                $('<div class="dx-icon-man">')
                                    .appendTo(container);
                            }
                            if (options.value === "female") {
                                console.log("h")
                                $('<div class="dx-icon-woman">')
                                    .appendTo(container);
                            }

                        }
                    },
                ]
            },
            {
                dataField: 'createdAt',
                allowEditing: false,
                width: "200px",
                dataType: 'date',
                alignment: 'right',
                hidingPriority: 0

            }
        ],
        onSelectionChanged(e) {
            e.component.refresh(true);
        },
        summary:
        {
            totalItems: [
                {
                    column: "salary",
                    summaryType: 'sum',
                    valueFormat: 'currency',
                    alignment: "center",
                    showInColumn: "job",
                },
                {
                    name: "SelectedRowsSummary",
                    showInColumn: 'name',
                    displayFormat: 'Sum of Selected Emp.: {0}',
                    valueFormat: 'currency',
                    summaryType: 'custom',
                }
            ],
            calculateCustomSummary(options) {
                if (options.name === "SelectedRowsSummary") {
                    if (options.summaryProcess === "start") {
                        options.totalValue = 0;
                    }
                    if (options.summaryProcess === "calculate") {
                        if (options.component.isRowSelected(options.value.id)) {
                            options.totalValue += parseInt(options.value.salary);
                        }
                    }
                }
            },
            groupItems: [
                {
                    column: "gender",
                    summaryType: "count",
                    alignByColumn: true
                }
            ],
        },
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
        // export
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
        }
        //onExporting: function (e) {
        //    exportDataToExcel(e.component);
        //    e.cancel = true;
        //}
    }).dxDataGrid('instance');;

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

///////////
//function exportDataToExcel(dataGrid) {
//    var workbook = new ExcelJS.Workbook();
//    var totalPages = dataGrid.pageCount();
//    var tasks = [];

//    for (let i = 0; i < totalPages; i++) {
//        tasks.push(exportPage(dataGrid, workbook, i));
//    }

//    Promise.all(tasks).then(function () {
//        workbook.xlsx.writeBuffer().then(function (buffer) {
//            saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'DataGrid.xlsx');
//        });
//    });
//}

//function exportPage(dataGrid, workbook, pageIndex) {
//    return new Promise((resolve) => {
//        dataGrid.pageIndex(pageIndex);
//        dataGrid.refresh().done(() => {
//            var worksheet = workbook.addWorksheet('Page ' + (pageIndex + 1));
//            DevExpress.excelExporter.exportDataGrid({
//                worksheet: worksheet,
//                component: dataGrid,
//                customizeCell: function (options) {
//                    var excelCell = options;
//                    excelCell.font = { name: 'Arial', size: 12 };
//                    excelCell.alignment = { horizontal: 'left' };
//                }
//            }).then(resolve);
//        });
//    });
//}