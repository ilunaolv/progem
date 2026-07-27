import { API } from './API.js';

export const Historico = {
  async load(processoId: string) {
    try {
      const data = await API.get(`/processo/${processoId}/historico`);
      this.renderTimeline(data);
    } catch (error) {
      console.error('Failed to load historico:', error);
    }
  },

  renderTimeline(items: any[]) {
    const container = document.getElementById('historico-container');
    if (!container) return;

    container.innerHTML = items.map(item => `
      <div class="timeline-item">
        <div class="timeline-date">${new Date(item.data).toLocaleDateString('pt-BR')}</div>
        <div class="timeline-content">
          <strong>${item.usuario}</strong> alterou <em>${item.campoAlterado}</em>
          <br />
          <small>De: ${item.valorAnterior}</small>
          <br />
          <small>Para: ${item.valorNovo}</small>
          <br />
          <small class="text-muted">IP: ${item.ip}</small>
        </div>
      </div>
    `).join('');
  }
};