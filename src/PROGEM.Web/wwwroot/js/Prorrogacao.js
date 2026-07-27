import { API } from './API.js';

export const Prorrogacao = {
  async create(processoId: string, dias: number, motivo: string, usuario: string) {
    const response = await API.post(`/processo/${processoId}/prorrogacao`, {
      quantidadeDias: dias,
      motivo,
      usuario
    });
    return response;
  },

  async list(processoId: string) {
    const data = await API.get(`/processo/${processoId}/prorrogacoes`);
    return data;
  }
};