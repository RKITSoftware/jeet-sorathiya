$(function () {
    const genderList = ["male", "female"];

    const states = [
        { id: 1, name: "Goa" },
        { id: 2, name: "Gujarat" },
        { id: 3, name: "Madhya Pradesh" },
        { id: 4, name: "Maharashtra" },
        { id: 5, name: "Rajasthan" },
        { id: 6, name: "Delhi" },
    ];

    const cities = {
        1: ["Panaji"],
        2: ["Jamnagar", "Morbi", "Rajkot", "Ahmedabad"],
        3: ["Bhopal", "Indore", "Gwalior"],
        4: ["Mumbai", "Pune", "Nagpur"],
        5: ["Jaipur", "Udaipur", "Jodhpur"],
        6: ["Delhi"],
    };

    const jobRoles = [
        { id: 1, role: "Full Stack Developer" },
        { id: 2, role: "Product Manager" },
        { id: 3, role: "Team Lead" },
        { id: 4, role: "Designer" },
        { id: 5, role: "Marketing Specialist" },
        { id: 6, role: "Sales Executive" },
        { id: 7, role: "HR Manager" }
    ];
    var roleSkills = {
        1: ["HTML", "CSS", "JavaScript", ".Net", "SQL", "Git"],
        2: ["Product Roadmap", "Stakeholder Management", "Project Management", "UX", "Strategic Thinking"],
        3: ["Leadership", "Project Management", "Technical Proficiency", "Conflict Resolution", "Communication", "Time Management", "Mentoring"],
        4: ["Graphic Design", "UX/UI Design", "Color Theory", "Creativity"],
        5: ["Market Research", "Digital Marketing", "Content Creation", "Brand Management", "Advertising"],
        6: ["Sales Techniques", "Negotiation Skills", "Presentation Skills", "Networking"],
        7: ["Recruitment", "Employee Relations", "Strategic HR Planning"]
    };

    const groupName = "form";

    $("#nameBox").dxTextBox({
        hint: "name",
        placeholder: "enter name"
    }).dxValidator({
        validationGroup: groupName,
        validationRules: [{
            type: "required",
            message: "Enter Name"
        }, {
            type: "stringLength",
            min: 3,
            max: 20,
            message: "Enter Valid Name"
        }]
    });

    $("#emailBox").dxTextBox({
        hint: "email",
        placeholder: "enter email",
        mode: "email"
    }).dxValidator({
        validationGroup: groupName,
        validationRules: [{
            type: "required",
            message: "Enter Email"
        }, {
            type: "email"
        }]
    });

    $("#phoneBox").dxTextBox({
        hint: "phone-number",
        placeholder: "enter phone number",
        mode: "tel"
    }).dxValidator({
        validationGroup: groupName,
        validationRules: [{
            type: "numeric",
            ignoreEmptyValue: false,
            message: "Enter Number"
        }, {
            type: "pattern",
            pattern: /^[6-9]\d{9}$/,
            message: "Enter Valid Number"
        }]
    });

    $("#dobBox").dxDateBox({
        hint: "date of birth",
        placeholder: "enter date of birth",
    }).dxValidator({
        validationGroup: groupName,
        validationRules: [{
            type: "required",
            message: "Enter Date of Birth"
        }, {
            type: "range",
            min: (function () {
                const today = new Date();
                return new Date(today.getFullYear() - 60, today.getMonth(), today.getDate()).getTime();
            })(),
            max: (function () {
                const today = new Date();
                return new Date(today.getFullYear() - 18, today.getMonth(), today.getDate()).getTime();
            })(),
            message: "Date of birth must be between 18 and 60 years ago"
        }]
    })

    $("#genderBox").dxRadioGroup({
        items: genderList,
        layout: "horizontal",
        value: "male",
        onValueChanged: function (e) {
            console.log("onValueChanged", e);
        }
    })

    $("#stateBox").dxSelectBox({
        dataSource: states,
        placeholder: "select your state",
        displayExpr: "name",
        valueExpr: "id",
        onValueChanged: function (e) {
            let stateId = e.value;
            let citySelectBox = $("#cityBox").dxSelectBox("instance");

            citySelectBox.option("dataSource", cities[stateId]);
            citySelectBox.option("disabled", false);
        }
    }).dxValidator({
        validationGroup: groupName,
        validationRules: [{
            type: "required",
            message: "Please select a state"
        }]
    });

    $("#cityBox").dxSelectBox({
        placeholder: "select your city",
        disabled: true
    }).dxValidator({
        validationGroup: groupName,
        validationRules: [{
            type: "required",
            message: "Please select a city"
        }]
    });

    $("#addressBox").dxTextArea({
        hint: "address",
        placeholder: "enter address"
    }).dxValidator({
        validationGroup: groupName,
        validationRules: [{
            type: "required",
            message: "Please enter address"
        }]
    });

    $("#roleBox").dxDropDownBox({
        hint: "Job Role",
        placeholder: "Select job role",
        dataSource: jobRoles,
        displayExpr: "role",
        valueExpr: "id",
        onValueChanged: function (e) {
            console.log(e);
        },
        contentTemplate: function (e) {
            const $list = $("<div>").dxList({
                dataSource: e.component.getDataSource(),
                itemTemplate: function (item) {
                    return $("<div>").text(item.role);
                },
                onItemClick: (selected) => {
                    e.component.option("value", selected.itemData.id);
                    console.log("value : ", e.component.option("value"));
                    console.log("selected : ", selected);
                    updateSkills(selected.itemData.id);
                    e.component.close();
                },
            });
            return $list;

        }
    }).dxValidator({
        validationGroup: groupName,
        validationRules: [{
            type: "required",
            message: "Please select a job role"
        }]
    });

    var container = $("#skillsBox");
    var checkedValues = [];

    function updateSkills(role) {
        container.empty();
        checkedValues = [];

        if (role) {
            var skills = roleSkills[role] || [];
            for (var i = 0; i < skills.length; i++) {
                var checkBoxId = "checkBox" + i;
                var checkBoxDiv = $("<div>").attr("id", checkBoxId).appendTo(container);

                checkBoxDiv.dxCheckBox({
                    text: skills[i],
                    readOnly: false,
                    onValueChanged: function (e) {
                        if (e.value) {
                            checkedValues.push(e.component.option("text"));
                        } else {
                            var index = checkedValues.indexOf(e.component.option("text"));
                            if (index !== -1) {
                                checkedValues.splice(index, 1);
                            }
                        }
                        console.log("Checked values: " + checkedValues.join(", "));
                    }
                });
            }
        }
    }


    updateSkills(null);

    $("#experienceBox").dxTextBox({
        hint: "experience",
        placeholder: "enter experience in years"
    }).dxValidator({
        validationGroup: groupName,
        validationRules: [{
            type: "range",
            min: 2,
            max: 10,
            reevaluate: false,
            message: "experience between 2 to 10 years required"
        }, {
            type: "numeric",
            ignoreEmptyValue: false,
            message: "Enter Experience"
        }]
    });

    $("#resumeBox").dxFileUploader({
        uploadMode: "useForm",
        accept: ".pdf",
        chunkSize: 10000,
    }).dxValidator({
        validationGroup: groupName,
        validationRules: [{
            type: "required",
            message: "Please upload resume"
        }]
    });

    function resetForm() {
        $("#nameBox").dxTextBox("instance").reset();
        $("#emailBox").dxTextBox("instance").reset();
        $("#phoneBox").dxTextBox("instance").reset();
        $("#dobBox").dxDateBox("instance").reset();
        $("#stateBox").dxSelectBox("instance").reset();
        $("#cityBox").dxSelectBox("instance").reset();
        $("#addressBox").dxTextArea("instance").reset();
        $("#roleBox").dxDropDownBox("instance").reset();
        $("#experienceBox").dxTextBox("instance").reset();
        $("#resumeBox").dxFileUploader("instance").reset();


        $("#skillsBox").empty();
        checkedValues = [];
    }
    $("#resetBTN").dxButton({
        text: 'reset',
        hint: "outlined",
        onClick: function () {
            resetForm();
        },
        stylingMode: "outlined",
        type: "info"
    });

    $("#submitBTN").dxButton({
        text: 'submit',
        hint: "contained",
        useSubmitBehavior: true,
        stylingMode: "contained",
        type: "success"
    })

    $('#form').submit(function (e) {
        const result = DevExpress.validationEngine.validateGroup(groupName);
        if (result.isValid) {
            var formData = {
                name: $("#nameBox").dxTextBox("instance").option("value"),
                email: $("#emailBox").dxTextBox("instance").option("value"),
                contactNumber: $("#phoneBox").dxTextBox("instance").option("value"),
                birthDate: $("#dobBox").dxDateBox("instance").option("value"),
                gender: $("#genderBox").dxRadioGroup("instance").option("value"),
                state: $("#stateBox").dxSelectBox("instance").option("value"),
                city: $("#cityBox").dxSelectBox("instance").option("value"),
                address: $("#addressBox").dxTextArea("instance").option("value"),
                jobRole: $("#roleBox").dxDropDownBox("instance").option("value"),
                experience: $("#experienceBox").dxTextBox("instance").option("value"),
                resume: $("#resumeBox").dxFileUploader("instance").option("value"),
                skills: checkedValues
            };
            sessionStorage.setItem("formData", JSON.stringify(formData));
            alert("Your job application has been successfully submitted. Thank you!");
        }
        else {
            alert("Please enter valid details.");
            e.preventDefault();
        }
    });

});
