function convertFirstLetterToUpperCase(text) {
    return text.charAt(0).toUpperCase() + text.slice(1);
}

function convertToShortDate(dateString) {
    const shortDate = new Date(dateString).toLocaleDateString('en-US');
    return shortDate;
}
function getJsonNetObject(obj, parentObj) {
    if (!obj) return null; // 👈 Bunu ekle (undefined/null için koruma)

    var objId = obj["$id"];
    if (typeof (objId) !== "undefined" && objId != null) {
        return obj;
    }

    objId = obj["$ref"];
    if (typeof (objId) !== "undefined" && objId != null) {
        return getJsonNetObjectById(parentObj, objId);
    }

    return null;
}
// function to return a JSON object by $id
// parentObj: the top level object containing all child objects as serialized by JSON.NET.
// id: the $id value of interest
function getJsonNetObjectById(parentObj, id) {
    // check if $id key exists.
    var objId = parentObj["$id"];
    if (typeof (objId) !== "undefined" && objId != null && objId == id) {
        // $id key exists, and the id matches the id of interest, so you have the object... return it
        return parentObj;
    }
    for (var i in parentObj) {
        if (typeof (parentObj[i]) == "object" && parentObj[i] != null) {
            //going one step down in the object tree
            var result = getJsonNetObjectById(parentObj[i], id);
            if (result != null) {
                // return found object
                return result;
            }
        }
    }
    return null;
}
function getTodaysDate() {
    let today = new Date();
    return `${today.getDate()}.${today.getMonth() + 1}.${today.getFullYear()}`;
}