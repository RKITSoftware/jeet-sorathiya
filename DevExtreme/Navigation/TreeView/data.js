const menuData = [
    {
        id: '1',
        name: 'Basics of Devextreme',
        items: [
            {
                id: '1_1',
                name: 'Introduction to DevExtreme',
                reconcile: true
            },
            {
                id: '1_2',
                name: 'Installation – NuGet Package',
            },
            {
                id: '1_3',
                name: 'Widget Basics - jQuery',
                items: [
                    {
                        id: '1_3_1',
                        name: 'Create and Configure a Widget'
                    },
                    {
                        id: '1_3_2',
                        name: 'Get a Widget Instance'
                    },
                    {
                        id: '1_3_3',
                        name: 'Get and Set Options'
                    },
                    {
                        id: '1_3_4',
                        name: 'Call Methods'
                    },
                    {
                        id: '1_3_5',
                        name: 'Handle Events'
                    },
                    {
                        id: '1_3_6',
                        name: 'Destroy a Widget'
                    },
                ],
            },
        ],
    },
    {
        id: '2',
        name: 'Editors – Overview',
        items: [
            {
                id: '2_1',
                name: 'Check Box',
            },
            {
                id: '2_2',
                name: 'Date Box',
            },
            {
                id: '2_3',
                name: 'Drop Down Box',
            },
            {
                id: '2_4',
                name: 'Number Box',
            },
            {
                id: '2_5',
                name: 'Select Box',
                items: [
                    {
                        id: '2_5_1',
                        name: 'Overview',
                    },
                    {
                        id: '2_5_2',
                        name: 'Search and Editing',
                    },
                    {
                        id: '2_5_3',
                        name: 'Grouped Items',
                    },
                ],
            },
            {
                id: '2_6',
                name: 'Text Area',
            },
            {
                id: '2_7',
                name: 'Text Box',
            },
            {
                id: '2_8',
                name: 'Button',
            },
            {
                id: '2_9',
                name: 'FileUploader',
            },
            {
                id: '2_10',
                name: 'Validation',
            },
            {
                id: '2_11',
                name: 'Radio Group',
            },
        ],
    },
    {
        id: '3',
        name: 'Data Layer',
        items: [
            {
                id: '3_1',
                name: 'ArrayStore',
                demo: true
            },
            {
                id: '3_2',
                name: 'CustomStore',
                demo: true
            },
            {
                id: '3_3',
                name: 'DataSource',
                demo: true
            },
            {
                id: '3_4',
                name: 'LocalStore',
                demo: true
            },
            {
                id: '3_5',
                name: 'Query',
                demo: true
            },
        ],
    },
    {
        id: '5',
        name: 'DataGrid',
        items: [
            {
                id: '5_1',
                name: 'Data Binding',
                items: [
                    {
                        id: '5_1_1',
                        name: 'Simple Array',
                    },
                    {
                        id: '5_1_2',
                        name: 'Ajax Request',
                    },
                ],
            },
            {
                id: '5_2',
                name: 'Paging and Scrolling',
                items: [
                    {
                        id: '5_2_1',
                        name: 'Record Paging',
                    },
                    {
                        id: '5_2_2',
                        name: 'Virtual Scrolling',
                    },
                    {
                        id: '5_2_3',
                        name: 'Infinite Scrolling',
                    },
                ],
            },
            {
                id: '5_3',
                name: 'Editing',
                items: [
                    {
                        id: '5_3_1',
                        name: 'Row Editing & Editing Events',
                    },
                    {
                        id: '5_3_2',
                        name: 'Batch Editing',
                    },
                    {
                        id: '5_3_3',
                        name: 'Cell Editing',
                    },
                    {
                        id: '5_3_4',
                        name: 'Form Editing',
                    },
                    {
                        id: '5_3_5',
                        name: 'Popup Editing',
                    },
                    {
                        id: '5_3_6',
                        name: 'Data Validation',
                    },
                    {
                        id: '5_3_7',
                        name: 'Cascading Lookups',
                    },
                ],
            },
            {
                id: '5_4',
                name: 'Grouping',
                items: [
                    {
                        id: '5_4_1',
                        name: 'Record Grouping',
                    },
                ],
            },
            {
                id: '5_5',
                name: 'Filtering',
                items: [
                    {
                        id: '5_5_1',
                        name: 'Filtering',
                    },
                    {
                        id: '5_5_2',
                        name: 'Filter Panel',
                    },
                ],
            },
            {
                id: '5_6',
                name: 'Sorting',
                items: [
                    {
                        id: '5_6_1',
                        name: 'Multiple Sorting',
                    },
                ],
            },
            {
                id: '5_7',
                name: 'Selection',
                items: [
                    {
                        id: '5_7_1',
                        name: 'Row Selection',
                    },
                    {
                        id: '5_7_2',
                        name: 'Multiple Record Selection Modes',
                    },
                ],
            },
            {
                id: '5_8',
                name: 'Columns',
                items: [
                    {
                        id: '5_8_1',
                        name: 'Column Customization',
                    },
                    {
                        id: '5_8_2',
                        name: 'Columns based on a Data Source',
                    },
                    {
                        id: '5_8_3',
                        name: 'Multi-Row Headers',
                    },
                    {
                        id: '5_8_4',
                        name: 'Column Resizing',
                    },
                    {
                        id: '5_8_5',
                        name: 'Command Column Customization',
                    },
                ],
            },
            {
                id: '5_9',
                name: 'State Persistence',
            },
            {
                id: '5_10',
                name: 'Appearance',
                items: [
                    {
                        id: '5_10_1',
                        name: 'Appearance',
                    },
                ],
            },
            {
                id: '5_11',
                name: 'Template',
                items: [
                    {
                        id: '5_11_1',
                        name: 'Column Template',
                    },
                    {
                        id: '5_11_2',
                        name: 'Row Template',
                    },
                    {
                        id: '5_11_3',
                        name: 'Cell Customization',
                    },
                    {
                        id: '5_11_4',
                        name: 'Toolbar Customization',
                    },
                ],
            },
            {
                id: '5_12',
                name: 'Data Summaries',
                items: [
                    {
                        id: '5_12_1',
                        name: 'Grid Summaries',
                    },
                    {
                        id: '5_12_2',
                        name: 'Group Summaries',
                    },
                    {
                        id: '5_12_3',
                        name: 'Custom Summaries',
                    },
                ],
            },
            {
                id: '5_13',
                name: 'Master-Detail',
                items: [
                    {
                        id: '5_13_1',
                        name: 'Master-Detail View',
                    },
                ],
            },
            {
                id: '5_14',
                name: 'Export',
            },
            {
                id: '5_15',
                name: 'Adaptability',
                items: [
                    {
                        id: '5_15_1',
                        name: 'Grid Adaptability Overview',
                    },
                    {
                        id: '5_15_2',
                        name: 'Grid Columns Hiding Priority',
                    },
                ],
            },
        ],
    },
    {
        id: '6',
        name: 'Navigation',
        items: [
            {
                id: '6_1',
                name: 'Overview',
            },
            {
                id: '6_2',
                name: 'Menu',
            },
            {
                id: '6_3',
                name: 'TreeView',
            },
        ],
    },
    {
        id: '7',
        name: 'Dialogues & Notification',
        items: [
            {
                id: '7_1',
                name: 'Overview',
            },
            {
                id: '7_2',
                name: 'Load Indicator',
            },
            {
                id: '7_3',
                name: 'Load Panel',
            },
            {
                id: '7_4',
                name: 'Popup',
            },
            {
                id: '7_5',
                name: 'Popover',
            },
            {
                id: '7_6',
                name: 'Toast',
            },
        ],
    },
];

const plainData = [
    {
        "id": "1",
        "name": "Basics of Devextreme"
    },
    {
        "id": "1_1",
        "name": "Introduction to DevExtreme",
        "parentId": "1",
        "reconcile": true
    },
    {
        "id": "1_2",
        "name": "Installation – NuGet Package",
        "parentId": "1"
    },
    {
        "id": "1_3",
        "name": "Widget Basics - jQuery",
        "parentId": "1"
    },
    {
        "id": "1_3_1",
        "name": "Create and Configure a Widget",
        "parentId": "1_3"
    },
    {
        "id": "1_3_2",
        "name": "Get a Widget Instance",
        "parentId": "1_3"
    },
    {
        "id": "1_3_3",
        "name": "Get and Set Options",
        "parentId": "1_3"
    },
    {
        "id": "1_3_4",
        "name": "Call Methods",
        "parentId": "1_3"
    },
    {
        "id": "1_3_5",
        "name": "Handle Events",
        "parentId": "1_3"
    },
    {
        "id": "1_3_6",
        "name": "Destroy a Widget",
        "parentId": "1_3"
    },
    {
        "id": "2",
        "name": "Editors – Overview"
    },
    {
        "id": "2_1",
        "name": "Check Box",
        "parentId": "2"
    },
    {
        "id": "2_2",
        "name": "Date Box",
        "parentId": "2"
    },
    {
        "id": "2_3",
        "name": "Drop Down Box",
        "parentId": "2"
    },
    {
        "id": "2_4",
        "name": "Number Box",
        "parentId": "2"
    },
    {
        "id": "2_5",
        "name": "Select Box",
        "parentId": "2"
    },
    {
        "id": "2_5_1",
        "name": "Overview",
        "parentId": "2_5"
    },
    {
        "id": "2_5_2",
        "name": "Search and Editing",
        "parentId": "2_5"
    },
    {
        "id": "2_5_3",
        "name": "Grouped Items",
        "parentId": "2_5"
    },
    {
        "id": "2_6",
        "name": "Text Area",
        "parentId": "2"
    },
    {
        "id": "2_7",
        "name": "Text Box",
        "parentId": "2"
    },
    {
        "id": "2_8",
        "name": "Button",
        "parentId": "2"
    },
    {
        "id": "2_9",
        "name": "FileUploader",
        "parentId": "2"
    },
    {
        "id": "2_10",
        "name": "Validation",
        "parentId": "2"
    },
    {
        "id": "2_11",
        "name": "Radio Group",
        "parentId": "2"
    },
    {
        "id": "3",
        "name": "Data Layer"
    },
    {
        "id": "3_1",
        "name": "ArrayStore",
        "parentId": "3",
        "demo": true
    },
    {
        "id": "3_2",
        "name": "CustomStore",
        "parentId": "3",
        "demo": true
    },
    {
        "id": "3_3",
        "name": "DataSource",
        "parentId": "3",
        "demo": true
    },
    {
        "id": "3_4",
        "name": "LocalStore",
        "parentId": "3",
        "demo": true
    },
    {
        "id": "3_5",
        "name": "Query",
        "parentId": "3",
        "demo": true
    },
    {
        "id": "5",
        "name": "DataGrid"
    },
    {
        "id": "5_1",
        "name": "Data Binding",
        "parentId": "5"
    },
    {
        "id": "5_1_1",
        "name": "Simple Array",
        "parentId": "5_1"
    },
    {
        "id": "5_1_2",
        "name": "Ajax Request",
        "parentId": "5_1"
    },
    {
        "id": "5_2",
        "name": "Paging and Scrolling",
        "parentId": "5"
    },
    {
        "id": "5_2_1",
        "name": "Record Paging",
        "parentId": "5_2"
    },
    {
        "id": "5_2_2",
        "name": "Virtual Scrolling",
        "parentId": "5_2"
    },
    {
        "id": "5_2_3",
        "name": "Infinite Scrolling",
        "parentId": "5_2"
    },
    {
        "id": "5_3",
        "name": "Editing",
        "parentId": "5"
    },
    {
        "id": "5_3_1",
        "name": "Row Editing & Editing Events",
        "parentId": "5_3"
    },
    {
        "id": "5_3_2",
        "name": "Batch Editing",
        "parentId": "5_3"
    },
    {
        "id": "5_3_3",
        "name": "Cell Editing",
        "parentId": "5_3"
    },
    {
        "id": "5_3_4",
        "name": "Form Editing",
        "parentId": "5_3"
    },
    {
        "id": "5_3_5",
        "name": "Popup Editing",
        "parentId": "5_3"
    },
    {
        "id": "5_3_6",
        "name": "Data Validation",
        "parentId": "5_3"
    },
    {
        "id": "5_3_7",
        "name": "Cascading Lookups",
        "parentId": "5_3"
    },
    {
        "id": "5_4",
        "name": "Grouping",
        "parentId": "5"
    },
    {
        "id": "5_4_1",
        "name": "Record Grouping",
        "parentId": "5_4"
    },
    {
        "id": "5_5",
        "name": "Filtering",
        "parentId": "5"
    },
    {
        "id": "5_5_1",
        "name": "Filtering",
        "parentId": "5_5"
    },
    {
        "id": "5_5_2",
        "name": "Filter Panel",
        "parentId": "5_5"
    },
    {
        "id": "5_6",
        "name": "Sorting",
        "parentId": "5"
    },
    {
        "id": "5_6_1",
        "name": "Multiple Sorting",
        "parentId": "5_6"
    },
    {
        "id": "5_7",
        "name": "Selection",
        "parentId": "5"
    },
    {
        "id": "5_7_1",
        "name": "Row Selection",
        "parentId": "5_7"
    },
    {
        "id": "5_7_2",
        "name": "Multiple Record Selection Modes",
        "parentId": "5_7"
    },
    {
        "id": "5_8",
        "name": "Columns",
        "parentId": "5"
    },
    {
        "id": "5_8_1",
        "name": "Column Customization",
        "parentId": "5_8"
    },
    {
        "id": "5_8_2",
        "name": "Columns based on a Data Source",
        "parentId": "5_8"
    },
    {
        "id": "5_8_3",
        "name": "Multi-Row Headers",
        "parentId": "5_8"
    },
    {
        "id": "5_8_4",
        "name": "Column Resizing",
        "parentId": "5_8"
    },
    {
        "id": "5_8_5",
        "name": "Command Column Customization",
        "parentId": "5_8"
    },
    {
        "id": "5_9",
        "name": "State Persistence",
        "parentId": "5"
    },
    {
        "id": "5_10",
        "name": "Appearance",
        "parentId": "5"
    },
    {
        "id": "5_10_1",
        "name": "Appearance",
        "parentId": "5_10"
    },
    {
        "id": "5_11",
        "name": "Template",
        "parentId": "5"
    },
    {
        "id": "5_11_1",
        "name": "Column Template",
        "parentId": "5_11"
    },
    {
        "id": "5_11_2",
        "name": "Row Template",
        "parentId": "5_11"
    },
    {
        "id": "5_11_3",
        "name": "Cell Customization",
        "parentId": "5_11"
    },
    {
        "id": "5_11_4",
        "name": "Toolbar Customization",
        "parentId": "5_11"
    },
    {
        "id": "5_12",
        "name": "Data Summaries",
        "parentId": "5"
    },
    {
        "id": "5_12_1",
        "name": "Grid Summaries",
        "parentId": "5_12"
    },
    {
        "id": "5_12_2",
        "name": "Group Summaries",
        "parentId": "5_12"
    },
    {
        "id": "5_12_3",
        "name": "Custom Summaries",
        "parentId": "5_12"
    },
    {
        "id": "5_13",
        "name": "Master-Detail",
        "parentId": "5"
    },
    {
        "id": "5_13_1",
        "name": "Master-Detail View",
        "parentId": "5_13"
    },
    {
        "id": "5_14",
        "name": "Export",
        "parentId": "5"
    },
    {
        "id": "5_15",
        "name": "Adaptability",
        "parentId": "5"
    },
    {
        "id": "5_15_1",
        "name": "Grid Adaptability Overview",
        "parentId": "5_15"
    },
    {
        "id": "5_15_2",
        "name": "Grid Columns Hiding Priority",
        "parentId": "5_15"
    },
    {
        "id": "6",
        "name": "Navigation"
    },
    {
        "id": "6_1",
        "name": "Overview",
        "parentId": "6"
    },
    {
        "id": "6_2",
        "name": "Menu",
        "parentId": "6"
    },
    {
        "id": "6_3",
        "name": "TreeView",
        "parentId": "6"
    },
    {
        "id": "7",
        "name": "Dialogues & Notification"
    },
    {
        "id": "7_1",
        "name": "Overview",
        "parentId": "7"
    },
    {
        "id": "7_2",
        "name": "Load Indicator",
        "parentId": "7"
    },
    {
        "id": "7_3",
        "name": "Load Panel",
        "parentId": "7"
    },
    {
        "id": "7_4",
        "name": "Popup",
        "parentId": "7"
    },
    {
        "id": "7_5",
        "name": "Popover",
        "parentId": "7"
    },
    {
        "id": "7_6",
        "name": "Toast",
        "parentId": "7"
    }
];

export { menuData, plainData }