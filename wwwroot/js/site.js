// Navigation Tab Switching
document.querySelectorAll('.nav-link').forEach(button => {
    button.addEventListener('click', () => {
        const targetId = button.getAttribute('data-target');
        switchTab(targetId);
    });
});

function switchTab(targetId) {
    document.querySelectorAll('.tab-section').forEach(section => {
        section.classList.remove('active');
    });
    document.querySelectorAll('.nav-link').forEach(btn => {
        btn.classList.remove('active');
        if (btn.getAttribute('data-target') === targetId) {
            btn.classList.add('active');
        }
    });

    const targetSection = document.getElementById(targetId);
    if (targetSection) {
        targetSection.classList.add('active');
    }
}

// Modal Controls
function openModal(modalId) {
    const modal = document.getElementById(modalId);
    if (modal) modal.classList.add('open');
}

function closeModal(modalId) {
    const modal = document.getElementById(modalId);
    if (modal) modal.classList.remove('open');
}

// Close modal when clicking outside the card
window.addEventListener('click', (e) => {
    if (e.target.classList.contains('modal-overlay')) {
        e.target.classList.remove('open');
    }
});

// Real-Time Active Show Search & Filtering
function filterShows() {
    const query = document.getElementById('show-search-input').value.toLowerCase().trim();
    const category = document.getElementById('show-category-filter').value;
    const registeredOnly = document.getElementById('show-registered-only').checked;

    const showCards = document.querySelectorAll('.show-item');

    showCards.forEach(card => {
        const searchableText = card.getAttribute('data-search') || '';
        const cardCategory = card.getAttribute('data-category') || '';
        const isRegistered = card.getAttribute('data-registered') === 'true';

        const matchesQuery = searchableText.includes(query);
        const matchesCategory = category === 'ALL' || cardCategory.includes(category);
        const matchesRegistration = !registeredOnly || isRegistered;

        if (matchesQuery && matchesCategory && matchesRegistration) {
            card.style.display = 'block';
        } else {
            card.style.display = 'none';
        }
    });
}