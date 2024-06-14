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

    $("#dtRowTemp").dxDataGrid({
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
        columnAutoWidth: true,
        columns: ["id", "name", "email", "job", "dob", "gender","createdAt"],
        rowTemplate(container, item) {
            console.log("j");
            const { data } = item;
            const grid = `
                <tr>
                    <td>${data.id}</td>
                    <td>${data.name}</td>
                    <td>${data.email}</td>
                    <td>${data.job}</td>
                    <td>${data.dob}</td>
                    <td>${data.gender}</td>
                    <td>${data.createdAt}</td>
                </tr>
            `;
            container.append(grid);
        }
    });
    


});