import 'styled-components';
import type { Theme } from './styles/tokens';

declare module 'styled-components' {
  export interface DefaultTheme extends Theme {}
}
