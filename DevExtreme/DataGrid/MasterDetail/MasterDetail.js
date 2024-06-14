import { employees, employeeExperiences } from './data.js';

$(() => {
    $('#dtMaster').dxDataGrid({
        dataSource: employees,
        keyExpr: 'employeeID',
        showBorders: true,
        columns: [
            { dataField: 'name', caption: 'Name' },
            { dataField: 'dob', caption: 'Date of Birth', dataType: 'date' },
            { dataField: 'gender', caption: 'Gender' },
            { dataField: 'email', caption: 'Email' },
            { dataField: 'phone', caption: 'Phone' }
        ],
        masterDetail: {
            enabled: true,
            template(container, options) {
                console.log("container", container);
                console.log("options", options);
                const currentEmployeeData = options.data;
                $('<div>')
                    .addClass('master-detail-caption')
                    .text(`${currentEmployeeData.name}'s Experience:`)
                    .appendTo(container);

                $('<div>')
                    .dxDataGrid({
                        columnAutoWidth: true,
                        showBorders: true,
                        columns: [
                            { dataField: 'jobRole', caption: 'Job Role' },
                            { dataField: 'companyName', caption: 'Company Name' },
                            { dataField: 'salary', caption: 'Salary', format: { type: 'currency', precision: 0 } },
                            { dataField: 'joiningDate', caption: 'Joining Date', dataType: 'date' },
                            { dataField: 'leftDate', caption: 'Left Date', dataType: 'date' }
                        ],
                        dataSource: new DevExpress.data.DataSource({
                            store: new DevExpress.data.ArrayStore({
                                key: 'id',
                                data: employeeExperiences,
                            }),
                            filter: ['employeeID', '=', options.key],
                        }),
                    })
                    .appendTo(container);
            },
        },
    });
});
