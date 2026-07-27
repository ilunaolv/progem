export function showModal(title: string, content: string, confirmText = 'Confirmar') {
  const modal = document.createElement('div');
  modal.className = 'modal fade show';
  modal.setAttribute('tabindex', '-1');
  modal.setAttribute('role', 'dialog');
  modal.innerHTML = `
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">${title}</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">${content}</div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
          <button type="button" class="btn btn-primary" id="modal-confirm">${confirmText}</button>
        </div>
      </div>
    </div>
  `;

  document.body.appendChild(modal);

  const bsModal = new bootstrap.Modal(modal);
  bsModal.show();

  return new Promise((resolve) => {
    modal.querySelector('#modal-confirm')?.addEventListener('click', () => {
      bsModal.hide();
      resolve(true);
    });
  });
}