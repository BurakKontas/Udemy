import { createBrowserRouter } from "react-router-dom";

import { Home } from "./pages/Home";

const router = createBrowserRouter([
    {
        path: "/",
        element: <Home />,
        errorElement: <div>An error occured</div>,
    },
]);

export default router;