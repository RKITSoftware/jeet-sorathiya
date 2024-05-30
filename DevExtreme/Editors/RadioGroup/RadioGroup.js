$(function () {

    const genderList = ["male", "female"]

    const KYCMethods = [
        { id: 1, method: "Email", value: "email", icon: "email" },
        { id: 2, method: "Phone", value: "phone", icon: "tel" },
        { id: 3, method: "In-Person", value: "in-person", icon: "user" },
        { id: 4, method: "Video Call", value: "video-call", icon: "photo" }
    ];

    $("#gender").dxRadioGroup({
        items: genderList,
        value: "male",
        onValueChanged: function (e) {
            console.log("onValueChanged", e);
        }
    });

    $("#kyc").dxRadioGroup({
        dataSource: KYCMethods,
        value: KYCMethods[3].value,
        displayExpr: "method",
        valueExpr: "value",
        layout: "horizontal",
        itemTemplate: function (data) {
            return `<div class="kyc-item">
                                <span class="dx-icon dx-icon-${data.icon}"></span>
                                <span>${data.method}</span>
                            </div>`;
        },
        onValueChanged: function (e) {
            console.log("onValueChanged", e);
        }
    });
});