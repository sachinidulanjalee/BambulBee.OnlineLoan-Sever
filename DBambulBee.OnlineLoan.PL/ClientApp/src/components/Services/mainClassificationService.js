export function deleteMainClassification(id) {
    // let employees = getAllEmployees();
    // employees = employees.filter(x => x.id != id)
    // localStorage.setItem(KEYS.employees, JSON.stringify(employees));
}
const KEYS = {
    mainClassifications: 'mainClassifications',
    mainClassificationsID: 'mainClassificationsId'
}

export function addMainClassifications(data) {
    fetch("https://localhost:44365/api/MainClassifications/Add", {
        method: "POST",
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(data)
    })
}

export function insertMainClassifications(data) {
    fetch("https://localhost:44365/api/MainClassifications/Add", {
        method: "POST",
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(data)
    })
}