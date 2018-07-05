//работа с корзиной
$(document).ready(function () {
    let cart = JSON.parse(localStorage.getItem('cart'))
    let cartItemsPlace = $("#cart-items-place")
    let totalSum = 0

    cart.items.forEach(function (item) {
        var tr = `
                    <tr data-id="${item.id}">
                            <td>
                                <img src="/Images/aromatnoe_lakomstvo_desert_tri_shokolada_2.jpg"> 
                            </td>
                            <td>    
                                <a href="/Home/Product?id=${item.id}">
                                    ${item.name}
                                </a>
                            </td>
                            <td>
                                ${item.price}
                            </td>
                            <td>
                                <input type="number" min="1" value="${item.quantity}" class="change_quantity" />
                                
                            </td>
                            <td class="total">
                                ${item.price * item.quantity}
                            </td>
                            <td class="cart_teble_remove">
                                <a href="#" class="remove_item">&#215;</a>
                            </td>
                        </tr>`    

        cartItemsPlace.append(tr);
        totalSum += item.price * item.quantity
    })
    //стоимость
    $('#total-price').html(totalSum)
    //очистить корзину
    $('#clear_cart').on('click', function () {
        localStorage.removeItem('cart')
        $("#cart-items-place").html('')
        $('#total-price').html(0)
        $('#cart-price').html(`0 <i class="fas fa-ruble-sign"></i>`)
    })
    //изменить количество товара
    $('.change_quantity').on('change', function () {
        let cart = JSON.parse(localStorage.getItem('cart'))
        let tr = $(this).parent("td").parent("tr")
        let itemId = tr.data('id')
        let quantity = $(this).val()
        let totalSum = 0

        cart.items.forEach(item => {
            if (item.id == itemId) {
                item.quantity = quantity
                let totalPrice = item.price * item.quantity
                tr.children('.total').html(totalPrice)
            }

            totalSum += item.price * item.quantity
        })

        localStorage.setItem('cart', JSON.stringify(cart)) 
        $('#total-price').html(`${totalSum} <i class="fas fa-ruble-sign"></i>`)
        $('#cart-price').html(`${totalSum} <i class="fas fa-ruble-sign"></i>`)
    })

    $('.remove_item').on('click', function () {
        let cart = JSON.parse(localStorage.getItem('cart'))

        let tr = $(this).parent("td").parent("tr")
        let itemId = tr.data('id')
        tr.empty()
        let totalSum = 0

        for (let i = 0; i<cart.items.length; i++) {
            if (cart.items[i].id == itemId) {
                cart.items.splice(i, 1)
                break
            } else {
                totalSum += cart.items[i].price * cart.items[i].quantity
            }
        }


        localStorage.setItem('cart', JSON.stringify(cart))  
        $('#total-price').html(`${totalSum} <i class="fas fa-ruble-sign"></i>`)
        $('#cart-price').html(`${totalSum} <i class="fas fa-ruble-sign"></i>`)
    })
})