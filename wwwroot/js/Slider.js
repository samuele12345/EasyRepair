const slides = document.querySelectorAll(".slide");
const slidesCont = document.querySelectorAll(".slide-cont");
const butAr = document.querySelector(".scroll-down");
const slides1 = document.querySelectorAll(".slide1");
const slides2 = document.querySelectorAll(".slide2");
const slides3 = document.querySelectorAll(".slide3");
const redDivs = document.querySelectorAll(".cont-gr");

if (slides.length > 0){
    let slideIndex = 0;
    let tInterval = null;

    window.addEventListener("DOMContentLoaded", defaultSlide)

    function defaultSlide(){
        slides[slideIndex].classList.add("desMain")
        slides1[slideIndex].classList.add("desMain");
        slides2[slideIndex].classList.add("desMain2");
        slides3[slideIndex].classList.add("sinMain");
        tInterval = setInterval(nextSlide, 5000);
    }

    function currentSlide(index){
        if(index >= slides.length){
            if(slides[0].classList.contains("desMain") && slides1[0].classList.contains("desMain") && slides2[0].classList.contains("desMain2")){
                slides[0].classList.remove("desMain");
                slides1[0].classList.remove("desMain")
                slides2[0].classList.remove("desMain2")
                slides3[0].classList.remove("sinMain")
            }

            index = 0;
            slides.forEach((sl, i) => {
                if (i !== slides.length - 1) {
                    sl.classList.remove("sin", "des", "desMain");
                    slides1[i].classList.remove("des")
                    slides2[i].classList.remove("active")
                    slides3[i].classList.remove("sin")
                    void sl.offsetWidth;
                    void slides1[i].offsetWidth;
                    void slides2[i].offsetWidth;
                    void slides3[i].offsetWidth;
                }
            });
            setTimeout(() => {
                slides[slides.length - 1].classList.remove("sin", "des", "desMain");
                slides1[slides1.length - 1].classList.remove("des");
                slides2[slides2.length - 1].classList.remove("active");
                slides3[slides3.length - 1].classList.remove("sin");
            }, 1000);
        }

        slideIndex = index;

        if (slideIndex % 2 == 0 || slideIndex == 0){
            slides[slideIndex].classList.add("des");
            
        }else{
            slides[slideIndex].classList.add("sin");
        }
        
        slides1[slideIndex].classList.add("des");
        slides2[slideIndex].classList.add("active");
        slides3[slideIndex].classList.add("sin");
    }
    
    function nextSlide(){
        slideIndex++;
        clearInterval(tInterval);
        tInterval = setInterval(nextSlide, 5000);
        currentSlide(slideIndex);
    }

    window.addEventListener('scroll', () => {
        const scrolled = window.pageYOffset;

        slidesCont.forEach(img => {
            const translateY = scrolled * 0.7;

            img.style.transform = `translateY(${translateY}px)`
        })
    });
}


if (butAr) {
    console.log(window.pageYOffset)
    butAr.addEventListener("click", () => {
        butAr.scrollIntoView({ behavior: 'smooth' });
    })
}

if (redDivs.length > 0) {
    redDivs[0].addEventListener("click", () => {
        window.location.href = "./ClientApp/src/App.jsx";
        console.log(yes);
    })
}
