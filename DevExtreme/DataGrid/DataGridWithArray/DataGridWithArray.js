$(function () {

    const companyData = [{
        ID: 1,
        CompanyName: 'Facebook India',
        Address: '123 Cyber City',
        City: 'Gurgaon',
        State: 'Haryana',
        Zipcode: 122002,
        Phone: '(0124) 5555-2797',
        Fax: '(0124) 5555-2171',
        Website: 'http://www.facebook.com/in',
    }, {
        ID: 2,
        CompanyName: 'Amazon India',
        Address: '456 Amazon Tower',
        City: 'Bangalore',
        State: 'Karnataka',
        Zipcode: 560103,
        Phone: '(080) 5955-3232',
        Fax: '(080) 5955-3231',
        Website: 'http://www.amazon.in',
    }, {
        ID: 3,
        CompanyName: 'Apple India',
        Address: '789 Apple Park',
        City: 'Bangalore',
        State: 'Karnataka',
        Zipcode: 560066,
        Phone: '(080) 3046-6073',
        Fax: '(080) 3046-6074',
        Website: 'http://www.apple.com/in',
    }, {
        ID: 4,
        CompanyName: 'Netflix India',
        Address: '123 Streaming Avenue',
        City: 'Mumbai',
        State: 'Maharashtra',
        Zipcode: 400001,
        Phone: '(022) 9555-2292',
        Fax: '(022) 9555-2293',
        Website: 'http://www.netflix.com/in',
    }, {
        ID: 5,
        CompanyName: 'Google India',
        Address: '456 Googleplex',
        City: 'Hyderabad',
        State: 'Telangana',
        Zipcode: 500081,
        Phone: '(040) 2862-2500',
        Fax: '(040) 2862-2501',
        Website: 'http://www.google.co.in',
    }, {
        ID: 6,
        CompanyName: 'Infosys Technologies',
        Address: '123 Electronics City',
        City: 'Bangalore',
        State: 'Karnataka',
        Zipcode: 560100,
        Phone: '(080) 2852-1234',
        Fax: '(080) 2852-5678',
        Website: 'http://www.infosys.com',
    }, {
        ID: 7,
        CompanyName: 'Tata Consultancy Services',
        Address: '456 TCS House',
        City: 'Mumbai',
        State: 'Maharashtra',
        Zipcode: 400001,
        Phone: '(022) 6778-9999',
        Fax: '(022) 6778-8888',
        Website: 'http://www.tcs.com',
    }, {
        ID: 8,
        CompanyName: 'Wipro Limited',
        Address: '789 Sarjapur Road',
        City: 'Bangalore',
        State: 'Karnataka',
        Zipcode: 560103,
        Phone: '(080) 2844-1234',
        Fax: '(080) 2844-5678',
        Website: 'http://www.wipro.com',
    }, , {
        ID: 9,
        CompanyName: 'Oracle India',
        Address: '123 Oracle Tech Park',
        City: 'Hyderabad',
        State: 'Telangana',
        Zipcode: 500081,
        Phone: '(040) 6789-7000',
        Fax: '(040) 6789-8000',
        Website: 'http://www.oracle.com/in',
    }, {
        ID: 10,
        CompanyName: 'Capgemini India',
        Address: '456 IT Park',
        City: 'Mumbai',
        State: 'Maharashtra',
        Zipcode: 400093,
        Phone: '(022) 6755-8000',
        Fax: '(022) 6755-9000',
        Website: 'http://www.capgemini.com/in',
    }, {
        ID: 11,
        CompanyName: 'Cognizant India',
        Address: '789 SIPCOT IT Park',
        City: 'Chennai',
        State: 'Tamil Nadu',
        Zipcode: 600119,
        Phone: '(044) 4596-3000',
        Fax: '(044) 4596-4000',
        Website: 'http://www.cognizant.com/in',
        }];

    $("#dtGrid").dxDataGrid({
        dataSource: companyData,
        keyExpr: "ID",
        allowColumnReordering: true, // reorder column
        columnAutoWidth: true, // auto adjust width
        allowColumnResizing: true, // resize column
        columnChooser: { enabled: true }, // remove column from list
        filterRow: { visible: true }, // add filter to each column
        searchPanel: { visible: true }, // add serach panel 
        groupPanel: { visible: true }, // group column
        focusedRowEnabled: true,
        focusedRowKey: 5,
        editing: {
            mode: "popup",
            allowUpdating: true,
            allowDeleting: true,
            allowAdding: true
        }, // enable edit/delete
        //columns: [
        //    {
        //        dataField: "ID",
        //        alignment: "center",
        //        width: "3%"
        //    },
        //    {
        //        dataField: "CompanyName",
        //      //  width: "13%"
        //    },
        //    {
        //        dataField: "Address"
        //    },
        //    {
        //        dataField: "City",
        //        width: "7%"
        //    },
        //    {
        //        dataField: "State",
        //        width: "7%"
        //    },
        //    {
        //        dataField: "Zipcode",
        //        width: "6%"
        //    },
        //    {
        //        dataField: "Phone",
        //        width: "10%"
        //    },
        //    {
        //        dataField: "Fax",
        //        width: "10%"
        //    },
        //    {
        //        dataField: "Website"
        //    }
        //],
       
    });


})