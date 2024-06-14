$(function () {

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
        },
        update: async function (key, values) {
            return await $.ajax({
                type: "PUT",
                url: `https://665d8d6de88051d604072435.mockapi.io/api/users/user/${key}`,
                contentType: 'application/json',
                data: JSON.stringify(values),
            })
        },
        insert: async function (values) {
            return await $.ajax({
                type: "POST",
                url: 'https://665d8d6de88051d604072435.mockapi.io/api/users/user',
                data: JSON.stringify(values),
            })
        },
        remove: async function (key) {
            return await $.ajax({
                type: "DELETE",
                url: `https://665d8d6de88051d604072435.mockapi.io/api/users/user/${key}`,
            })
        }
    });

    const dataGrid = $("#dtCellGrid").dxDataGrid({
        dataSource: apiData,

        // show only this column and this order       
        // columns: ["id", "name", "email", "job", "dob", "gender", "createdAt"],
        paging: {
            pageSize: 10, // total record in one page
            pageIndex: 0   // page index that show
        },
        pager: {
            showPageSizeSelector: true, // set how many record show in one page
            allowedPageSizes: [10, 20, 50], // set how many record show in one page
            showNavigationButtons: true, // show arrow for navigation
            showInfo: true, // enable info text
            infoText: "Page #{0}. Total: {1} ({2} items)", // info text
        },
        editing: {
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            mode: 'cell',
            // confirmDelete: false
        },
        onOptionChanged: function (e) {
            console.log(e.component.option('editing.changes')); // see only what value changed
        },
        columns: [
            {
                dataField: 'id',
                caption: "User Id",
                allowEditing: false,
                width: "90px",
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
                    max: 20,
                    message: "Enter Valid Job Title"
                }]
            },
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
                width: "100px",
                validationRules: [{
                    type: "required",
                    message: "Enter Gender"
                }]

            },
            {
                dataField: 'createdAt',
                allowEditing: false,
                width: "200px",

            },
            {
                type: 'buttons',
                buttons: ['edit', 'delete'],
                fixed: true,
                fixedPosition: "right"
            }
        ]
    }).dxDataGrid("instance");


    dataGrid.on("editingStart", function (e) {
        console.log('Editing started:', e);
    });

    dataGrid.on("initNewRow", function (e) {
        console.log('Initializing new row:', e);
    });

    dataGrid.on("rowInserting", function (e) {
        console.log('Inserting new row:', e);
    });

    dataGrid.on("rowInserted", function (e) {
        console.log('New row inserted:', e);
    });

    dataGrid.on("rowUpdating", function (e) {
        console.log('Updating row:', e);
    });
    dataGrid.on("rowUpdated", function (e) {
        console.log('Row updated:', e);
    });

    dataGrid.on("rowRemoving", function (e) {
        console.log('Removing row:', e);
    });

    dataGrid.on("rowRemoved", function (e) {
        console.log('Row removed:', e);
    });
});