loadItems()

document.addEventListener("DOMContentLoaded", () => {
    const inpText = document.querySelector(".inp");

    inpText.addEventListener("keyup", () => {
        const inpCont = inpText.value;
        loadItems(inpCont)
    })
})

async function loadItems(searchString = "") {
    var itType = 0;
    var html = "";
    const itList = document.querySelector(".dev-list");
    const stat = document.querySelector(".status");

    stat.textContent = "Loading items..."

    const response = await fetch(`/Item/ItemsDev?inputVal=${encodeURIComponent(searchString)}&itType=${encodeURIComponent(itType)}`);

    if (!response.ok) {
        throw new Error(`Error status ${response.status}`);
    }

    items = await response.json();

    items.forEach(item => {
        html += `
            <li>${item.name}</li>
        `
    })

    itList.innerHTML = html;
    stat.textContent = "";
}