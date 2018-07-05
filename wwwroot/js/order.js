$(document).ready(function () {
    $('#checkout').on('click', function () {
        let order = {
            firstName: $("#firstname").val(),
            lastName: $("#lastname").val(),
            comment: $("#comment").val(),
            phone: $("#phone").val(),
            address: $("#address").val(),
            deliveryDate: $("#delivery-date").val(),
            orderItems: [],
            deliverys: {
                id: $("#delivery-method").val()
            }
        }

        let cart = JSON.parse(localStorage.getItem('cart'))


        cart.items.forEach(item => {
            order.orderItems.push({
                product: {
                    id: item.id
                },
                quantity: item.quantity,
                price: item.price
            })
        })

        console.log(order)

        localStorage.removeItem('cart')


        $.post("/Home/Checkout", order).done(function (data) {
            document.location.href = "/"
        });

    })

    let cart = JSON.parse(localStorage.getItem('cart'))
    let totalPrice = 0

    cart.items.forEach(item => {
        totalPrice += item.price*item.quantity
    })

    $('#total-price').html(totalPrice)
})