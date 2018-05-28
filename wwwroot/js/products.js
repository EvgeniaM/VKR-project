//добавление товара в корзину по кнопке
    $(document).on('click', '.add_item', function(){
        let cart = JSON.parse(localStorage.getItem('cart')) 
        let itemIsExist = false 
        let itemId = $(this).data("id") 
        let totalSum = 0

        //если в корзине не пусто, изменяем сумму товаров в корзине, при этом 
        //если добавляем тот же товар, то изменяем количество этого товара
        if (cart) { 
            cart.items.forEach(function(item){ 
                totalSum += item.price * item.quantity
                if (item.id == itemId) { 
                    itemIsExist = true 
                    item.quantity++ 
                } 
            }) 
        } else { 
            cart = { 
                items: [] 
            } 
        } 
    
        if (!itemIsExist) { 
            cart.items.push({ 
                id: $(this).data("id"), 
                name: $(this).data("name"), 
                price: $(this).data("price"), 
                quantity: 1 
            }) 
        } 
        
        $('#cart-price').html(`${totalSum} <i class="fas fa-ruble-sign"></i>`)
        localStorage.setItem('cart', JSON.stringify(cart)) 
    })