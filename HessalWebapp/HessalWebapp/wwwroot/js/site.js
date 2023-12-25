"use strict";

console.log("Page init"); 

/* Page Loader */
window.addEventListener("load", () => {
    const loader = document.querySelector(".loader");
    loader.classList.add("loader-hidden");

    loader.addEventListener("transitionend", () => {
        document.body.removeChild("loader");
    })
});


    function toggleContent() {
        var content = document.getElementById("load-more");
    // Toggle the display property
    content.style.display = (content.style.display === "none") ? "block" : "none";
    }

/* OffCanvas Menu Button */
var offCanvasButton = document.getElementById("offcanvasButton")
var menu = document.getElementById("menu");
var navButtonclose = document.getElementById("nav-button-close");
var collapseProjects = document.getElementById("collapseProjects");
var collapseSolutions = document.getElementById("collapseSolutions");

offCanvasButton.onclick = function () {
    menu.classList.toggle("open-menu");
}

navButtonclose.addEventListener('click', () => {
    menu.classList.toggle("open-menu");
    collapseProjects.classList.remove('show');
    collapseSolutions.classList.remove('show');
});

///* Vision-Mission Overlay Animation */
//const visionOverlay = document.getElementById("vision-overlay");
//const missionOverlay = document.getElementById("mission-overlay");

//visionOverlay.addEventListener('mouseenter', () => {
//    visionOverlay.classList.add("animated", "flipInX", "visible");
//})

//visionOverlay.addEventListener('mouseleave', () => {
//    visionOverlay.classList.remove("animated", "flipInX", "visible");
//})

//missionOverlay.addEventListener('mouseenter', () => {
//    missionOverlay.classList.add("animated", "flipInX", "visible");
//})

//missionOverlay.addEventListener('mouseleave', () => {
//    missionOverlay.classList.remove("animated", "flipInX", "visible");
//})

/* OffCanvas Custom Overlay */
function toggleOffcanvas() {
    var offcanvas = document.getElementById('offcanvasHessal');
    var overlay = document.getElementById('overlay');
    document.body.classList.toggle('offcanvas-open'); // Toggle class to prevent scrolling
    offcanvas.classList.toggle('show'); // Toggle Bootstrap's 'show' class
    overlay.style.display = overlay.style.display === 'block' ? 'none' : 'block'; // Toggle the overlay
}
// Event Listener
document.getElementById('offcanvasButton').addEventListener('click', toggleOffcanvas);
document.getElementById('nav-button-close').addEventListener('click', toggleOffcanvas);

/* Button Submit */
const PIP_EL = {
    submit: document.getElementById("sub_button"),
    email: document.getElementById("email"),
    loading: document.getElementById("btn-loading")
};

let canSubmit = false;

function PIP_can_submit() {
    let email = PIP_EL.email.value.trim();
    if (email.length > 4) {
        PIP_enable_submit()
    } else {
        PIP_disable_submit()
    }
}

function PIP_enable_submit() {
    PIP_EL.submit.classList.add("submit_enabled");
    PIP_EL.submit.disabled = false;
    canSubmit = true;
}

function PIP_disable_submit() {
    PIP_EL.submit.classList.remove("submit_enabled");
    PIP_EL.submit.disabled = true;
    canSubmit = false;
}

function PIP_set_event_listeners() {
    PIP_EL.email.addEventListener("keyup", PIP_can_submit);
}

var Pipebuild = {
    init: function () {
        this.Component.init();
    },
    Component: {
        init: function () {
            this.forms();
        },
        forms: function () {
            // Contact Form
            var $contactForm = $('#contact-form');

            if ($contactForm.length > 0) {
                $contactForm.submit(function () {
                    var $btn = $(this).find('.btn-loading');
                    var $form = $(this);
                    var response;
                    const subButton = document.getElementById("sub_button");
                    if ($form.valid()) {
                        $('.btn-loading').show();
                        $('.btn-submit').hide();
                        //  XMLHttpRequest to get output from .php file and print on the console.
                        //Start
                        var xhttp = new XMLHttpRequest();
                        var dateTiming;
                        xhttp.onreadystatechange = function () {
                            if (this.readyState == 4 && this.status == 200) {
                                dateTiming = this.responseText;
                            }
                        };
                        xhttp.open("GET", "mail.php", true);
                        xhttp.send();
                        //End
                        $.ajax({
                            type: 'POST',
                            url: 'mail.php',
                            data: $form.serialize(),
                            error: function (err) {
                                setTimeout(function () {
                                    $('.col-message, .error-message').show();
                                    $('.btn-loading').hide();
                                    $('.btn-submit').show();
                                    PIP_disable_submit();
                                }, 2000);
                            },
                            success: function (responseText) {
                                var funcResponse = responseText.trim();
                                var match = funcResponse.match(/success/i);
                                if (match !== null) {
                                    response = 'success';
                                } else {
                                    response = 'error';
                                }
                                setTimeout(function () {
                                    $btn.addClass(response);
                                    $('.col-message, .success-message').show();
                                    PIP_disable_submit();
                                    $('.btn-loading').hide();
                                    $('.btn-submit').show();

                                }, 800);
                                console.log("Response: ", response);
                            },
                            complete: function (data) {
                                setTimeout(function () {
                                    $('.btn-loading').hide();
                                    $('.btn-submit').show();
                                    PIP_disable_submit();
                                }, 4000);
                            }
                        });
                        return false;
                    }
                    return false;
                });
            }
        }
    }
};

$(document).ready(function () {

    Pipebuild.init();

    /* Animation SlideIn */
    if ($(".contact-box").length > 0) {
        var animationDone = false;

        $(window).scroll(function () {

            if (!animationDone) {
                var scrollPos = $(window).scrollTop();
                var contactBox = $(".contact-box");
                var sectionOffset = contactBox.offset().top;

                if (scrollPos > sectionOffset - $(window).height() / 2) {
                    contactBox.removeClass("is-notvisible").addClass("animated slideInDown");
                    animationDone = true;
                }
            }
        });
    }

    /* Sticky Setting */
    $(function () {
        "use strict";
        if ($(".navbar-sticky").length > 0) {
            $(".navbar-sticky").sticky({ topSpacing: 0 });
            $(".navbar-sticky").css('z-index', '100');
            $(".navbar-sticky").addClass("top-nav-collapse");
        };
    });

    $(window).scroll(function () {
        if ($(this).scrollTop() > 56) { // Adjusted based on navbar height
            $(".navbar-sticky").addClass("animated slideInDown");
            $(".navbar-sticky").addClass('bg-light');
        } else {
            $(".navbar-sticky").removeClass("animated slideInDown");
            $(".navbar-sticky").removeClass('bg-light');
        }
    });

    /* Count */
    $(function () {
        "use strict";
        $(".fact-number").appear(function () {
            var dataperc = $(this).attr('data-perc');
            $(this).each(function () {
                $(this).find('.factor').delay(6000).countTo({
                    from: 10,
                    to: dataperc,
                    speed: 3000,
                    refreshInterval: 50,
                });
            });
        });
    });

    /* Isotope Layout */
    $(function () {
        var $listing = $(".box-listing").isotope({
            itemSelector: '.box-item',
            layoutMode: 'fitRows',
            getSortData: {
                number: '.item-id parseInt',
                name: '.item-name',
                category: '[data-category]'
            }
        });

        $("#filters").on("click", "button", function () {
            var filterValue = $(this).attr('data-filter');
            $listing.isotope({ filter: filterValue });
        });

        $("#sorts").on("click", "button", function () {
            var sortValue = $(this).attr('data-sort-by');
            $listing.isotope({ sortBy: sortValue });
        });
    });

    $(function () {
        var $listing = $(".portfolio-grid").isotope({
            masonry: {
            },
            getSortData: {
                number: '.item-id parseInt',
                name: '.item-name',
                category: '[data-category]'
            }
        });

        $("#project-filter").on("click", "a", function () {
            event.preventDefault();

            var filterValue = $(this).attr('data-filter');
            $listing.isotope({ filter: filterValue });
        });
    });
});

/* Footer Toggle Menu Button*/
const buttons = {
    button1: document.getElementById("btn-close-1"),
    button2: document.getElementById("btn-close-2"),
    button3: document.getElementById("btn-close-3"),
    button4: document.getElementById("btn-close-4")
};

for (const key in buttons) {
    if (buttons.hasOwnProperty(key)) {
        buttons[key].setAttribute('data-touch-count', 0);
        buttons[key].setAttribute('data-click-count', 0);

        buttons[key].addEventListener('click', () => {
            buttons[key].classList.add("btn-click");
            const clickCount = parseInt(buttons[key].getAttribute('data-click-count'));
            buttons[key].setAttribute('data-click-count', clickCount + 1); // increment click count by 1 for each button

            if (clickCount === 1) {
                buttons[key].classList.remove("btn-click");
                buttons[key].setAttribute('data-click-count', 0); // reset click count to 0 for each button
            }
        });

        buttons[key].addEventListener('touchstart', () => {
            buttons[key].classList.add("btn-click");
            const touchCount = parseInt(buttons[key].getAttribute('data-touch-count'));
            buttons[key].setAttribute('data-touch-count', touchCount + 1); // increment touch count by 1 for each button
        });

        buttons[key].addEventListener('touchend', () => {
            const touchCount = parseInt(buttons[key].getAttribute('data-touch-count'));
            if (touchCount === 1) {
                buttons[key].classList.remove("btn-click");
                buttons[key].setAttribute('data-touch-count', 0);
            }
        });
    }
}

//// MUTATION OBSERVER - MONITORS DYNAMIC CONTENT - FUTURE REFERENCE
//// Function to be called when the "show" class is added or removed
//function handleShowClassChange(mutationsList, observer) {
//    for (const mutation of mutationsList) {
//        if (mutation.type === 'attributes' && mutation.attributeName === 'class') {
//            // Check if the "show" class has been added to the "offCanvas" element
//            if (offCanvas.classList.contains('show')) {
//                console.log("The 'show' class has been added to offCanvas");

//            } else {
//                console.log("The 'show' class has been removed from offCanvas");

//            }
//        }
//    }
//}

////// Create a MutationObserver to watch for changes in the "class" attribute of the "offCanvas" element
////var observer = new MutationObserver(handleShowClassChange);

////// Start observing changes
////observer.observe(offCanvas, { attributes: true });

////// To stop observing changes (optional)
/////* observer.disconnect();*/
//// MUTATION OBSERVER - MONITORS DYNAMIC CONTENT - FUTURE REFERENCE

