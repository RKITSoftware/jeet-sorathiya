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
        }
    });

    $("#dtAjax").dxDataGrid({
        dataSource: apiData,
       // height: "400px",
        // show only this column and this order       
        columns: ["id", "name", "email", "job", "dob", "gender", "createdAt"],
        searchPanel: { visible: true }, // add serach panel 
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
        scrolling: {
         //  mode: "infinite", // call other data when scroll reached end(see aria-rowcount attribute)
          // mode: "virtual", // all data load directly
        }
    });

});