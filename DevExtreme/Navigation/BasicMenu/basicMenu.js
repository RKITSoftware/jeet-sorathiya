$(function () {
    const menu = $("#menu").dxMenu({
        items: [
            {
                icon: 'home'
            },
            {
                text: 'About'
            },
            {
                text: 'Products',
                items: [
                    {
                        text: 'Product 1',
                    },
                    {
                        text: 'Category',
                        items: [
                            {
                                text: 'Product 2'
                            },
                            {
                                text: 'Product 3'
                            }
                        ]
                    },
                ]
            },
        ],
        onItemClick: function (e) {
            console.log(e);
        }

    }).dxMenu('instance');
});