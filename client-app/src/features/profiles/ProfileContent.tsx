import React from 'react';
import { Tab } from 'semantic-ui-react';
import ProfilePhotos from './ProfilePhotos';
import { Profile } from '../../app/models/profile';


interface Props {
    profile: Profile;
}


export default function ProfileContent({profile}: Props) {
    const panes = [
        { menuItem: 'About', render: () => <Tab.Pane>About content</Tab.Pane> },
        { menuItem: 'Photos', render: () => <ProfilePhotos profile={profile}/> },
        { menuItem: 'Events', render: () => <Tab.Pane>Events content</Tab.Pane> },
        { menuItem: 'Followers', render: () => <Tab.Pane>Followers content</Tab.Pane> },
        { menuItem: 'Following', render: () => <Tab.Pane>Following content</Tab.Pane> },
    ];
    return (
        <Tab
            menu={{ fluid: true, vertical: true }}
            menuPosition='right'
            panes={panes}
        />
    )
}
