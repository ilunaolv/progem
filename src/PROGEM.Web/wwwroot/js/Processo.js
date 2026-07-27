import { API } from './API.js';

export const Processo = {
  async loadList(page = 1) {
    try {
      const search = document.getElementById('search-input')?.value || '';
      const natureza = document.getElementById('filtro-natureza')?.value || '';
      const status = document.getElementById('filtro-status')?.value || '';

      const params = new URLSearchParams({ page: page.toString(), search, natureza, status });
      const data = await API.get(`/processo?${params.toString()}`);
      this.renderTable(data.items);
      this.renderPagination(data.totalPages, data.page);
    } catch (error) {
      console.error('Failed to load processes:', error);
    }
  },

  renderTable(items) {
    const tbody = document.getElementById('processos-tbody');
    if (!tbody) return;

    tbody.innerHTML = items.map(p => `
      <tr>
        <td><a href="/processos/${p.id}">${this.escapeHtml(p.numero)}</a></td>
        <td>${this.escapeHtml(p.numero)}</td>
        <td>${p.ano}</td>
        <td>${p.natureza}</td>
        <td>${p.categoria}</td>
        <td>${this.escapeHtml(p.requerente)}</td>
        <td><span class="badge bg-${this.getStatusBadge(p.status)}">${p.status}</span></td>
        <td>
          <a href="/processos/${p.id}" class="btn btn-sm btn-primary">Ver</a>
        </td>
      </tr>
    `).join('');
  },

  renderPagination(totalPages, currentPage) {
    const pagination = document.getElementById('pagination');
    if (!pagination) return;

    let html = '';
    for (let i = 1; i <= totalPages; i++) {
      html += `<li class="page-item ${i === currentPage ? 'active' : ''}">
        <a class="page-link" href="#" data-page="${i}">${i}</a>
      </li>`;
    }
    pagination.innerHTML = html;
  },

  getStatusBadge(status) {
    const badges: Record<string, string> = {
      'Preliminar': 'info',
      'Portaria': 'primary',
      'Sindicancia': 'warning',
      'Inquisito': 'danger',
      'Sumario': 'secondary',
      'Prorrogado': 'dark',
      'Concluso': 'success',
      'Arquivado': 'secondary',
      'Reaberto': 'warning',
      'Encerrado': 'secondary'
    };
    return badges[status] || 'secondary';
  },

  escapeHtml(text: string): string {
    const div = document.createElement('div');
    div.textContent = text;
    return div.innerHTML;
  }
};