function scrollToBottom(elementId) {
    const chatArea = document.getElementById(elementId);
    if (chatArea) {
        chatArea.scrollTop = chatArea.scrollHeight;
    }
}