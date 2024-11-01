// Error.stories.tsx
import Home from './Home';
import { withRouter } from 'storybook-addon-remix-react-router';

export default {
    title: 'Pages/Home',
    component: Home,
    decorators: [withRouter()],
};

const Template = () => <Home />;

export const DefaultError = Template.bind({});
// DefaultError.args = {
// };
