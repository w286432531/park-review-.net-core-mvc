// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//get page title from body class which is set in shared layout
let pageTitle = document.querySelector("body").getAttribute("class");
//set value for first time running script when page load
let count = 1;
function starTransform() {
    //declare number of stars as num
    let num;
    //check if it's first time running function
    if (count == 1) {
        //if currently on create review page. rating will be empty this statement will be true
        if (document.querySelector(".starRating").value == "") {
            //set stars to 0
            num = 0;
            //add to count so count is not equal 1 next time it's run.
            count++;        
        } else {
            //if it's not on create page then it's on the edit review page.
            //set number of stars to current rating
            num = parseInt(document.querySelector(".starRating").value);
            //add to count so count is not equal 1 next time it's run.
            count++;
        }
    }
    else //if it's not the first time
    {   //stars =  fifth character in alt attribute
        num = parseInt(this.getAttribute("alt")[5]);
    }
    // set input field value to number of stars
    document.querySelector(".starRating").value = num;
    //declare a string for new html
    let newhtml = ``;
    // loop through number of stars to print out stars
    for (let i = 1; i <= num; i++) {
        newhtml += `<img src="/icon/star.png" alt="stars${i}" class="starIcon star${i} " />`;
    }
    // loop through rest of stars to fill in empty stars
    for (let i = num + 1; i <= 5; i++) {
        newhtml += `<img src="/icon/emptystar.png" alt="stars${i}" class="starIcon star${i} " />`;
    }
    // fill in stars div with new html
    document.querySelector(".stars").innerHTML = newhtml;
    // add event listener to stars to run this function again
    for (let i = 1; i <= 5; i++) {
        document
            .querySelector(".star" + i)
            .addEventListener("click", starTransform);
    }

}

if (pageTitle == "Create Review" || pageTitle == "Edit Review") {
    //call function the first time.
    starTransform();
}


