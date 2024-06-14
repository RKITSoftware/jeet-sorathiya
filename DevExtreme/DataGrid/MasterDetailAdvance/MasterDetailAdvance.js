import { employees, jobDetails, jobDurations } from './data.js';
window.jsPDF = window.jspdf.jsPDF;
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
            template: masterDetailTemplate
        },
        export: {
            enabled: true,
            formats: ['pdf'],
          //  allowExportSelectedData: true
        },
        onExporting(e) {
            const doc = new jsPDF();

            DevExpress.pdfExporter.exportDataGrid({
                jsPDFDocument: doc,
                component: e.component,
                indent: 5,
            }).then(() => {
                doc.save('Companies.pdf');
            });
        },
    });
});

function masterDetailTemplate(container, options) {
    const currentEmployeeData = options.data;
    $('<div>').dxDataGrid({
        dataSource: jobDetails.filter(job => job.employeeID === currentEmployeeData.employeeID),
        keyExpr: 'id',
        showBorders: true,
        columns: [
            { dataField: 'jobRole', caption: 'Job Role' },
            { dataField: 'companyName', caption: 'Company Name' }
        ],
        masterDetail: {
            enabled: true,
            template: (innerContainer, innerOptions) => {
                const jobDurationDetails = jobDurations.filter(duration => duration.id === innerOptions.data.id);
                $('<div>').dxDataGrid({
                    dataSource: jobDurationDetails,
                    showBorders: true,
                    columns: [
                        { dataField: 'salary', caption: 'Salary', dataType: 'number', format: 'currency' },
                        { dataField: 'joiningDate', caption: 'Joining Date', dataType: 'date' },
                        { dataField: 'leftDate', caption: 'Left Date', dataType: 'date' }
                    ]
                }).appendTo(innerContainer);
            }
        }
    }).appendTo(container);
    //

}

//


