$(function () {

    const states = [
        { ID: 1, Name: 'Haryana' },
        { ID: 2, Name: 'Karnataka' },
        { ID: 3, Name: 'Maharashtra' },
        { ID: 4, Name: 'Telangana' },
        { ID: 5, Name: 'Tamil Nadu' }
    ];

    const cities = [
        { ID: 1, Name: 'Gurgaon', StateID: 1 },
        { ID: 2, Name: 'Bangalore', StateID: 2 },
        { ID: 3, Name: 'Mumbai', StateID: 3 },
        { ID: 4, Name: 'Hyderabad', StateID: 4 },
        { ID: 5, Name: 'Chennai', StateID: 5 }
    ];

    const updatedCompanyData = [
        {
            ID: 1,
            CompanyName: 'Facebook India',
            Address: '123 Cyber City',
            CityID: 1,
            StateID: 1,
            Website: 'http://www.facebook.com/in'
        },
        {
            ID: 2,
            CompanyName: 'Amazon India',
            Address: '456 Amazon Tower',
            CityID: 2,
            StateID: 2,
            Website: 'http://www.amazon.in'
        },
        {
            ID: 3,
            CompanyName: 'Apple India',
            Address: '789 Apple Park',
            CityID: 2,
            StateID: 2,
            Website: 'http://www.apple.com/in'
        },
        {
            ID: 4,
            CompanyName: 'Netflix India',
            Address: '123 Streaming Avenue',
            CityID: 3,
            StateID: 3,
            Website: 'http://www.netflix.com/in'
        },
        {
            ID: 5,
            CompanyName: 'Google India',
            Address: '456 Googleplex',
            CityID: 4,
            StateID: 4,
            Website: 'http://www.google.co.in'
        },
        {
            ID: 6,
            CompanyName: 'Infosys Technologies',
            Address: '123 Electronics City',
            CityID: 2,
            StateID: 2,
            Website: 'http://www.infosys.com'
        },
        {
            ID: 7,
            CompanyName: 'Tata Consultancy Services',
            Address: '456 TCS House',
            CityID: 3,
            StateID: 3,
            Website: 'http://www.tcs.com'
        },
        {
            ID: 8,
            CompanyName: 'Wipro Limited',
            Address: '789 Sarjapur Road',
            CityID: 2,
            StateID: 2,
            Website: 'http://www.wipro.com'
        },
        {
            ID: 9,
            CompanyName: 'Oracle India',
            Address: '123 Oracle Tech Park',
            CityID: 4,
            StateID: 4,
            Website: 'http://www.oracle.com/in'
        },
        {
            ID: 10,
            CompanyName: 'Capgemini India',
            Address: '456 IT Park',
            CityID: 3,
            StateID: 3,
            Website: 'http://www.capgemini.com/in'
        },
        {
            ID: 11,
            CompanyName: 'Cognizant India',
            Address: '789 SIPCOT IT Park',
            CityID: 5,
            StateID: 5,
            Website: 'http://www.cognizant.com/in'
        }
    ];



    $("#dtCascading").dxDataGrid({
        dataSource: updatedCompanyData,
        keyExpr: "ID",
        editing: {
            allowUpdating: true,
            allowAdding: true,
            mode: 'row',
        },
        columns: [
            { dataField: 'ID', },
            { dataField: 'CompanyName', },
            { dataField: 'Address', },
            {
                dataField: 'StateID',
                caption: 'State',
                setCellValue(rowData, value) {
                    rowData.StateID = value;
                    rowData.CityID = null;
                },
                lookup: {
                    dataSource: states,
                    valueExpr: 'ID',
                    displayExpr: 'Name',
                },
            },
            {
                dataField: 'CityID',
                caption: 'City',
                lookup: {
                    dataSource(options) {
                        return {
                            store: cities,
                            filter: options.data ? ['StateID', '=', options.data.StateID] : null,
                        };
                    },
                    valueExpr: 'ID',
                    displayExpr: 'Name',
                },
            },
        ]
    });
});