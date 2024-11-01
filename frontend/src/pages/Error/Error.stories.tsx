// Error.stories.tsx
import Error from './Error';
import { withRouter } from 'storybook-addon-remix-react-router';

export default {
    title: 'Pages/Error',
    component: Error,
    decorators: [withRouter()],
};

const Template = () => <Error />;

export const DefaultError = Template.bind({});