//добавление товара в корзину по кнопке
    $(document).on('click', '.add_item', function(){
        let cart = JSON.parse(localStorage.getItem('cart')) //помещаем в переменную cart данные из локалсторейдж
        let itemIsExist = false 
        let itemId = $(this).data("id") //помещаем айди сохраняемого продукта
        let totalSum = 0 //итоговая сумма

        //если в корзине не пусто: изменяем сумму товаров в корзине, при этом 
        //если добавляем тот же товар, то изменяем количество этого товара
        if (cart) { //если в корзине есть товар
            cart.items.forEach(function(item){ 
                totalSum += item.price * item.quantity //изменяем стоимость
                if (item.id == itemId) { //если тот же товар, то увеличиваем количество
                    itemIsExist = true 
                    item.quantity++ 
                } 
            }) 
        } else { //если корзина пустая то инициализируем айтемы (позиции)
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