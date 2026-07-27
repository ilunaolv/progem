export function initSidebar() {
  const toggleBtn = document.getElementById('sidebar-toggle');
  const sidebar = document.querySelector('.sidebar');

  if (toggleBtn && sidebar) {
    toggleBtn.addEventListener('click', () => {
      sidebar.classList.toggle('sidebar-collapsed');
    });
  }
}

export function initTooltips() {
  const tooltipTriggerList = [].slice.call(
    document.querySelectorAll('[data-bs-toggle="tooltip"]')
  );
  tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl);
  });
}

export function initAutoSave() {
  const forms = document.querySelectorAll('form[data-autosave]');
  forms.forEach(form => {
    let timeout: ReturnType<typeof setTimeout> | null = null;
    form.addEventListener('input', () => {
      if (timeout) clearTimeout(timeout);
      timeout = setTimeout(() => {
        form.requestSubmit();
      }, 2000);
    });
  });
}

export function initToast() {
  window.showToast = function (message: string, type: string = 'info') {
    const toastEl = document.createElement('div');
    toastEl.className = `toast show bg-${type} text-white`;
    toastEl.setAttribute('role', 'alert');
    toastEl.innerHTML = `
      <div class="toast-body">${message}</div>
    `;
    document.body.appendChild(toastEl);
    setTimeout(() => toastEl.remove(), 3000);
  };
}