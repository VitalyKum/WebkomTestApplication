function toggleInputElementSwitchFilterVLanID() {
    var input = document.getElementById("inputVLanIdMin");
    input.disabled = !input.disabled;

    input = document.getElementById("inputVLanIdMax");
    input.disabled = !input.disabled;
}

function toggleInputElementSwitchFilterFloorNumber() {
    var input = document.getElementById("inputFloorNumberMin");
    input.disabled = !input.disabled;

    input = document.getElementById("inputFloorNumberMax");
    input.disabled = !input.disabled;
}

function toggleInputElementSwitchFilterPurchaseDate() {
    var input = document.getElementById("inputPurchaseDateMin");
    input.disabled = !input.disabled;

    input = document.getElementById("inputPurchaseDateMax");
    input.disabled = !input.disabled;
}

function toggleInputElementSwitchFilterConnectDate() {
    var input = document.getElementById("inputConnectDateMin");
    input.disabled = !input.disabled;

    input = document.getElementById("inputConnectDateMax");
    input.disabled = !input.disabled;
}