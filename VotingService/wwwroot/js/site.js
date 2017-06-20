// Write your Javascript code.

/* This function calls the StatefulBackendController's HTTP GET method to get a collection of KeyValuePairs from the reliable dictionary in the StatefulBackendService */
function getStatefulBackendServiceDictionary() {
    var http = new XMLHttpRequest();
    http.onreadystatechange = function () {
        if (http.readyState === 4) {
            end = new Date().getTime();
            if (http.status < 400) {
                returnData = JSON.parse(http.responseText);
                if (returnData) {
                    renderStatefulBackendServiceDictionary(returnData);
                    updateFooter(http, (end - start));
                    //postMessage("Got all KeyValuePairs in  " + (end - start).toString() + "ms.", "success", true);
                }
            } else {
                updateFooter(http, (end - start));
                //postMessage(http.statusText, "danger", true);
            }
        }
    };
    start = new Date().getTime();
    http.open("GET", "/api/Votes/" + start);
    http.send();
}

/* This function calls the StatefulBackendController's HTTP PUT method to insert a KeyValuePair in the reliable dictionary in the StatefulBackendService */
function addStatefulBackendServiceKeyValuePair() {
    var keyValue = {
        key: keyInput.value,
        value: valueInput.value
    };
    var http = new XMLHttpRequest();
    http.onreadystatechange = function () {
        if (http.readyState === 4) {
            end = new Date().getTime();
            if (http.status < 400) {
                keyInput.value = '';
                valueInput.value = '';
                keyInput.focus();
                updateFooter(http, (end - start));
            } else {
                keyInput.focus();
                updateFooter(http, (end - start));
            }
        }
    };
    start = new Date().getTime();
    http.open("PUT", "/api/Votes/" + start);
    http.setRequestHeader("content-type", "application/json");
    http.send(JSON.stringify(keyValue));
}

/* This function renders the output of the call to the Stateful Backend Service in a table */
function renderStatefulBackendServiceDictionary(dictionary) {
    var table = document.getElementById('statefulBackendServiceTable').childNodes[1];

    while (table.childElementCount > 1) {
        table.removeChild(table.lastChild);
    }

    for (var i = 0; i < dictionary.length; i++) {
        var tr = document.createElement('tr');
        var tdKey = document.createElement('td');
        tdKey.appendChild(document.createTextNode(dictionary[i].key));
        tr.appendChild(tdKey);
        var tdValue = document.createElement('td');
        tdValue.appendChild(document.createTextNode(dictionary[i].value));
        tr.appendChild(tdValue);
        table.appendChild(tr);
    }
}

/*This function puts HTTP result in the footer */
function updateFooter(http, timeTaken) {
    toggleFooter(1);
    if (http.status < 299) {
        statusPanel.className = 'panel panel-success';
        statusPanelHeading.innerHTML = http.status + ' ' + http.statusText;
        statusPanelBody.innerHTML = 'Result returned in ' + timeTaken.toString() + ' ms from ' + http.responseURL;
    }
    else {
        statusPanel.className = 'panel panel-danger';
        statusPanelHeading.innerHTML = http.status + ' ' + http.statusText;
        statusPanelBody.innerHTML = http.responseText;
    }
}