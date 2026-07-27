import { API } from './API.js';

export const Dashboard = {
  async load() {
    try {
      const data = await API.get('/dashboard');
      this.updateCards(data);
      this.updateCharts(data);
    } catch (error) {
      console.error('Failed to load dashboard:', error);
    }
  },

  updateCards(data) {
    const totalEl = document.getElementById('total-processos');
    const abertosEl = document.getElementById('processos-abertos');
    const vencendoEl = document.getElementById('processos-vencendo');
    const atrasadosEl = document.getElementById('processos-atrasados');

    if (totalEl) totalEl.textContent = data.totalProcessos || 0;
    if (abertosEl) abertosEl.textContent = data.processosAbertos || 0;
    if (vencendoEl) vencendoEl.textContent = data.processosVencendo || 0;
    if (atrasadosEl) atrasadosEl.textContent = data.processosAtrasados || 0;
  },

  updateCharts(data) {
    const naturezaCtx = document.getElementById('chartNatureza');
    const categoriaCtx = document.getElementById('chartCategoria');

    if (naturezaCtx) {
      new Chart(naturezaCtx, {
        type: 'doughnut',
        data: {
          labels: ['Preliminar', 'Sindicancia', 'Inquisito', 'Sumario'],
          datasets: [{
            data: data.porNatureza || [0, 0, 0, 0],
            backgroundColor: ['#4e73df', '#1cc88a', '#e74a3b', '#f6c23e']
          }]
        }
      });
    }

    if (categoriaCtx) {
      new Chart(categoriaCtx, {
        type: 'pie',
        data: {
          labels: ['Dano ao Erario', 'Infracao Disciplinar'],
          datasets: [{
            data: data.porCategoria || [0, 0],
            backgroundColor: ['#4e73df', '#e74a3b']
          }]
        }
      });
    }
  }
};