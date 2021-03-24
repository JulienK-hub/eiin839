//document.getElementById("workingTest").innerHTML = "It works !";


function contractsRetrieved() {
    var datalist = document.getElementById("datalist1")
    const json = this.responseText
    const obj = JSON.parse(json);   
    for (var item of obj) {
        var option = document.createElement("option")
        option.setAttribute("value", item.name)
        datalist.appendChild(option)

    }
}
function retrieveAllContracts() {
    var key = document.getElementById("input1").value;
    // key = 39571097c1e9b087e872bf8c82780a117c246f85
    const url = new URL("https://api.jcdecaux.com/vls/v1/contracts?apiKey=" + key)
    var request = new XMLHttpRequest();
    request.open("get", url)
    request.setRequestHeader("Accept", "application/json")
    request.onload = contractsRetrieved
    request.send()
}