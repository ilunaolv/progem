import { API } from './API.js';

export const Anexos = {
  async upload(processoId: string, file: File) {
    const formData = new FormData();
    formData.append('file', file);

    try {
      const response = await fetch(`/api/documento/upload?processoId=${processoId}`, {
        method: 'POST',
        headers: {
          'Authorization': `Bearer ${API.getToken()}`
        },
        body: formData
      });

      if (!response.ok) throw new Error('Upload failed');
      return response.json();
    } catch (error) {
      console.error('Upload error:', error);
      throw error;
    }
  },

  preview(file: File): Promise<string> {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.onload = () => resolve(reader.result as string);
      reader.onerror = reject;
      reader.readAsDataURL(file);
    });
  }
};