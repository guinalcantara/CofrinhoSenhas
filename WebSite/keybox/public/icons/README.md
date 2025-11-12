# Ícones para PWA

Para que o PWA funcione corretamente, você precisa adicionar os seguintes ícones nesta pasta:

## Tamanhos necessários:
- icon-72x72.png
- icon-96x96.png
- icon-128x128.png
- icon-144x144.png
- icon-152x152.png
- icon-192x192.png
- icon-384x384.png
- icon-512x512.png

## Como gerar os ícones:

### Opção 1: Online (Recomendado)
Use https://realfavicongenerator.net/ - Faz upload de uma imagem e gera todos os tamanhos

### Opção 2: Ferramenta CLI
```bash
npm install -g pwa-asset-generator
pwa-asset-generator logo.png ./public/icons
```

### Opção 3: Manualmente
Crie um logo.png 512x512 e redimensione para cada tamanho necessário

## Dica:
O ícone deve ter fundo sólido e design simples para funcionar bem em todos os tamanhos.
Cor sugerida: #6366f1 (theme-color do manifest)
