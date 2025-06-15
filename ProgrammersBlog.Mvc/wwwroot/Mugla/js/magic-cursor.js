document.addEventListener('DOMContentLoaded', () => {
    // Magic Cursor Effect
    const cursorOrb = document.createElement('div');
    cursorOrb.style.position = 'fixed';
    cursorOrb.style.width = '20px';
    cursorOrb.style.height = '20px';
    cursorOrb.style.borderRadius = '50%';
    cursorOrb.style.background = 'radial-gradient(circle, rgba(59, 130, 246, 0.8), rgba(139, 92, 246, 0.8))';
    cursorOrb.style.boxShadow = '0 0 15px rgba(139, 92, 246, 0.7)';
    cursorOrb.style.pointerEvents = 'none';
    cursorOrb.style.zIndex = '9999';
    cursorOrb.style.transition = 'transform 0.1s ease-out';
    document.body.appendChild(cursorOrb);

    document.addEventListener('mousemove', (e) => {
        cursorOrb.style.transform = `translate(${e.clientX - 10}px, ${e.clientY - 10}px)`;
        // Create more particles for a denser effect
        createParticle(e.clientX, e.clientY);
        createParticle(e.clientX, e.clientY);
        createParticle(e.clientX, e.clientY);
    });

    function createParticle(x, y) {
        const particle = document.createElement('div');
        particle.style.position = 'fixed';
        particle.style.left = `${x}px`;
        particle.style.top = `${y}px`;
        const size = Math.random() * 7 + 4; // Increased size from 2-7px to 4-11px
        particle.style.width = `${size}px`;
        particle.style.height = `${size}px`;
        particle.style.borderRadius = '50%';
        const color = `hsl(${Math.random() * 360}, 90%, 70%)`;
        particle.style.background = color;
        particle.style.pointerEvents = 'none';
        particle.style.zIndex = '9998';
        document.body.appendChild(particle);

        particle.animate([
            { transform: 'translate(-50%, -50%) scale(1)', opacity: 1 },
            { transform: `translate(${(Math.random() - 0.5) * 50}px, ${(Math.random() - 0.5) * 50 + 20}px) scale(0)`, opacity: 0 }
        ], {
            duration: 1000,
            easing: 'ease-out'
        });

        setTimeout(() => {
            particle.remove();
        }, 1000);
    }
});
