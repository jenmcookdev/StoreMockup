var pethairinventory = [
{
    id: 1,
    item: "Brushed",
    price: 15

},
{
    id: 2,
    item: "Fur Ritzy",
    price: 35
},
{
    id: 3,
    item: "Almost Invisible",
    price: 9
},
{
    id: 4,
    item: "Back40",
    price: 55
},
{
    id: 5,
    item: "By the Boot",
    price: 250
},
{
    id: 6,
    item: "Natural Fuzzy Blanket",
    price: 70
},
{
    id: 7,
    item: "Lantern",
    price: 150
},
{
    id: 8,
    item: "Lurking",
    price: 110
},
{
    id: 9,
    item: "Edifurble",
    price: 3
},
{
    id: 10,
    item: "Fluffer Puff",
    price: 33
}
];

/* store the  cart information*/
var cart = [];

//add items to the cart
function addToCart(id) {
    var petHair = pethairinventory[id - 1];
    if (typeof petHair.qty === 'undefined') {
        petHair.qty = 1;
        cart.push(petHair); // LIFO
    } else {
        petHair.qty = petHair.qty + 1;
    }
    /*Testing purposes only*/
    //console.clear();
    var arrayLength = cart.length;
    for (var i = 0; i < arrayLength; i++) {
        console.log(cart[i]);
    }

    $('.notification-counter').css("display", "block");
    //document.getElementById('cart-notification').style.display = 'block'; //added number to cart
    //document.getElementById('cart-notification-moble').style.display = 'block'; //added number to cart


    //To get the quantity that is added to cart
    var cartQty = 0;
    for (var i = 0; i < arrayLength; i++) {
        cartQty += cart[i].qty;
    }

    $('span.notification-counter').text(cartQty);
    //document.getElementById('cart-notification').innerHTML = cartQty;
    //document.getElementById('cart-notification-moble').innerHTML = cartQty;

    console.log(document.getElementById('cart-notification'));
    //console.log(document.getElementById('cart-notification-moble'));

    document.getElementById('cart-contents').innerHTML = getCartContents();
}//add to cart ends

function getCartContents() {
    var cartContent = "";
    var cartTotal = 0;

    //Displays the item, qty, price, and total price of all cart contents

    for (var i = 0; i < cart.length; i++) {
        cartContent += "Item: " + cart[i].item + "<br/>QTY: " + cart[i].qty + "<br/>Price: " + cart[i].price + "<br/>";
        cartTotal += cart[i].price * cart[i].qty;
    };

    cartContent += "Cart Total: $" + cartTotal.toFixed(2);
    return cartContent;

}//end get cart contents


