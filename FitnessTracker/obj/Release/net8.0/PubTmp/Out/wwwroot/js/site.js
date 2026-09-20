// ========================================
// FitnessTracker - Animation Scripts
// ========================================

(function () {
    'use strict';

    // Page Load Animation
    window.addEventListener('load', function () {
        document.body.classList.add('loaded');
    });

    // Smooth Scroll
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                target.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });

    // Add animation class when element is in viewport
    function animateOnScroll() {
        const elements = document.querySelectorAll('.animate-on-scroll');

        const observer = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    entry.target.classList.add('fade-in');
                }
            });
        }, {
            threshold: 0.1
        });

        elements.forEach(element => {
            observer.observe(element);
        });
    }

    // Initialize animations
    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', animateOnScroll);
    } else {
        animateOnScroll();
    }

    // Add hover effect to cards (for future use)
    document.addEventListener('DOMContentLoaded', function () {
        const cards = document.querySelectorAll('.card');
        cards.forEach(card => {
            card.addEventListener('mouseenter', function () {
                this.style.transition = 'transform 0.3s ease, box-shadow 0.3s ease';
                this.style.transform = 'translateY(-5px)';
            });

            card.addEventListener('mouseleave', function () {
                this.style.transform = 'translateY(0)';
            });
        });
    });

    // Number counter animation (for future dashboard metrics)
    function animateCounter(element, target, duration = 2000) {
        let start = 0;
        const increment = target / (duration / 16);

        const timer = setInterval(() => {
            start += increment;
            if (start >= target) {
                element.textContent = Math.round(target);
                clearInterval(timer);
            } else {
                element.textContent = Math.round(start);
            }
        }, 16);
    }

    // Expose functions globally for future use
    window.FitnessTracker = {
        animateCounter: animateCounter,
        animateOnScroll: animateOnScroll
    };

})();