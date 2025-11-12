// Verifica se a string é nula, vazia, undefined ou só espaços
export function isNullOrEmpty(value?: string | null): boolean {
  return !value || value.trim().length === 0;
}

// Coloca a primeira letra em maiúscula
export function capitalizeFirstLetter(value: string): string {
  if (isNullOrEmpty(value)) return "";
  return value.charAt(0).toUpperCase() + value.slice(1);
}

// Limita o texto em X caracteres e adiciona "..." se ultrapassar
export function truncate(value: string, maxLength: number): string {
  if (isNullOrEmpty(value)) return "";
  return value.length > maxLength
    ? value.substring(0, maxLength) + "..."
    : value;
}
