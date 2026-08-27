// @ts-check
import { defineConfig } from 'astro/config';
import starlight from '@astrojs/starlight';

// https://astro.build/config
export default defineConfig({
	integrations: [
		starlight({
			title: 'vbnet-format',
			social: [{ icon: 'github', label: 'GitHub', href: 'https://github.com/lionniedermeier/vbnet-format' }],
			sidebar: [
				{
					label: 'Guides',
					items: [
						{ label: 'Getting Started', slug: 'guides/getting-started' },
					],
				},
				{
					label: 'Formatter',
					items: [{ autogenerate: {directory: 'formatter'}}]
				}
			],
		}),
	],
});
