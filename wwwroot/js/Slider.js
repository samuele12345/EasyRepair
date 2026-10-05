const slides = document.querySelectorAll(".slide");
const slidesCont = document.querySelectorAll(".slide-cont");
const butAr = document.querySelector(".scroll-down");
const slides2 = document.querySelectorAll(".slide2");

if (slides.length > 0){
    let slideIndex = 0;
    let tInterval = null;

    window.addEventListener("DOMContentLoaded", defaultSlide)

    function defaultSlide(){
        slides[slideIndex].classList.add("desMain")
        slides2[slideIndex].classList.add("desMain2");
        tInterval = setInterval(nextSlide, 5000);
    }

    function currentSlide(index){
        if(index >= slides.length){
            index = 0;
            slides.forEach((sl, i) => {
                if (i !== slides.length - 1) {
                    sl.classList.remove("sin", "des", "desMain");
                    void sl.offsetWidth;
                }
            });
            setTimeout(() => {
                slides[slides.length - 1].classList.remove("sin", "des", "desMain");
            }, 1000);

            slides2.forEach((sl2, i) => {
                if (i !== slides2.length - 1) {
                    sl2.classList.remove("active");
                    void sl2.offsetWidth;
                }
            });
            setTimeout(() => {
                slides2[slides2.length - 1].classList.remove("active");
            }, 1000);
        }

        slideIndex = index;

        if (slideIndex % 2 == 0 || slideIndex == 0){
            slides[slideIndex].classList.add("des");
            
        }else{
            slides[slideIndex].classList.add("sin");
        }
        
        slides2[slideIndex].classList.add("active");
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