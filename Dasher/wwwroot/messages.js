function truncateText(selector, maxChars) {
    const elements = document.querySelectorAll(selector);
    elements.forEach((element) => {
        const originalText = element.textContent;
        if (originalText.length > maxChars) {
            element.textContent = originalText.substring(0, maxChars) + "...";
        }
    });
}

// Run the function on page load
document.addEventListener("DOMContentLoaded", function () {
    truncateText(".user-box__subtitle", 10);
});