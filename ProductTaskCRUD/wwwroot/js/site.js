document.addEventListener('DOMContentLoaded', function () {
    var cards = document.querySelectorAll('.card');
    cards.forEach(function (card) {
        card.classList.add('fade-in');
    });
});


function setAction(action) {
    document.getElementById('GFG').action = `/Product/GetProduct?searchProp=&method=${action}`;
    document.getElementById("GFG").submit();
}

const input = document.querySelector("input");
function checkInput() {
    let str = input.value.trim()
    if (str.length === 0) {
        alert("Please enter ID or Name of the product")
        return false;
    }
    return true
}

function submitPage() {
    document.getElementById("GFG").submit();
}
