import sharp from 'sharp';
import { readFileSync } from 'fs';
import { join, dirname } from 'path';
import { fileURLToPath } from 'url';

const __filename = fileURLToPath(import.meta.url);
const __dirname = dirname(__filename);

const sizes = [72, 96, 128, 144, 152, 192, 384, 512];

// SVG simples com fundo colorido e ícone de cadeado
const svg = `
<svg width="512" height="512" viewBox="0 0 512 512" xmlns="http://www.w3.org/2000/svg">
  <rect width="512" height="512" fill="#6366f1"/>
  <g transform="translate(256, 256)">
    <rect x="-80" y="-20" width="160" height="120" rx="8" fill="white"/>
    <rect x="-60" y="-80" width="120" height="100" rx="60" fill="none" stroke="white" stroke-width="20"/>
    <circle cx="0" cy="30" r="15" fill="#6366f1"/>
    <rect x="-5" y="30" width="10" height="30" fill="#6366f1"/>
  </g>
</svg>
`;

async function generateIcons() {
  for (const size of sizes) {
    await sharp(Buffer.from(svg))
      .resize(size, size)
      .png()
      .toFile(join(__dirname, `public/icons/icon-${size}x${size}.png`));
    console.log(`✓ Gerado icon-${size}x${size}.png`);
  }
  console.log('✅ Todos os ícones foram gerados!');
}

generateIcons().catch(console.error);
