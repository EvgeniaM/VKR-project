$(document).ready(function () {
    $('#checkout').on('click', function () {
        let order = {
            firstName: $("#firstname").val(),
            lastName: $("#lastname").val(),
            comment: $("#comment").val(),
            phone: $("#phone").val(),
            address: $("#address").val(),
            orderItems: []
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
        
        
        $.post("/Home/Checkout", order).done(function(data) {
            document.location.href = "/"
        });

    })
})