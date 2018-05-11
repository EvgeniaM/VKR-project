$(document).ready(function () {
    let cart = JSON.parse(localStorage.getItem('cart'))
    let totalSum = 0

    cart.items.forEach(function (item) {
        totalSum += item.price * item.quantity
    })

    $('#cart-price').html(`${totalSum} <i class="fas fa-ruble-sign"></i>`)

})
