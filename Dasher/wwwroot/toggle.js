function toggleChange() {
    const body = document.querySelector("body");
    const toggle = document.querySelector(".available__toggle");
    const label = document.querySelector(".available__label");
    const space = document.querySelector(".available__space");
    toggle.addEventListener("click", () => {
        toggle.classList.toggle("active");
        label.classList.toggle("active");
        space.classList.toggle("active");
    });
};
function btnClicked() {
    const buttons = document.querySelectorAll(".services__btn");
    buttons.forEach(button => {
        button.addEventListener('click', () => {
            button.classList.toggle('active');
        });
    });
};
function saveCandidate() {
    const save_btns = document.querySelectorAll(".card__bottom-save");
    save_btns.forEach(btn => {
        btn.addEventListener('click', () => {
            btn.classList.toggle('active');
        });
    });
};
function seeDetails() {
    const details_btns = document.querySelectorAll(".card__bottom-details");
    details_btns.forEach(btn => {
        btn.addEventListener('click', () => {
            btn.classList.toggle('active');
        });
    });
};