function changeProgressbar() {
    const progressbar1 = document.querySelector("#progress1");
    const progressbar2 = document.querySelector("#progress2");
    const progressbar3 = document.querySelector("#progress3");

    function resetProgressbar() {
        progressbar1.classList.remove("active");
        progressbar2.classList.remove("active");
        progressbar3.classList.remove("active");

        progressbar1.classList.add("deactive");
        progressbar2.classList.add("deactive");
        progressbar3.classList.add("deactive");
    }

    progressbar1.addEventListener("click", () => {
        resetProgressbar();
        progressbar1.classList.add("active");
        progressbar1.classList.remove("deactive");
    });

    progressbar2.addEventListener("click", () => {
        resetProgressbar();
        progressbar2.classList.add("active");
        progressbar2.classList.remove("deactive");
    });

    progressbar3.addEventListener("click", () => {
        resetProgressbar();
        progressbar3.classList.add("active");
        progressbar3.classList.remove("deactive");
    });
}
